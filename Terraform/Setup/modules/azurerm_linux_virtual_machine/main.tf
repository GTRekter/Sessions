/* ========================================
  Networking
======================================== */
resource "azurerm_public_ip" "public_ip" {
    name                = "pip-${var.project_name}-${var.location_abbreviation}-${format("%02d", var.virtual_machine_instance_number)}"
    location            = var.location
    resource_group_name = var.resource_group_name
    allocation_method   = "Static"
    tags                = var.tags
}
resource "azurerm_network_security_group" "security_group" {
  name                = "nsg-${var.project_name}-${var.location_abbreviation}-${format("%02d", var.virtual_machine_instance_number)}"
  location            = var.location
  resource_group_name = var.resource_group_name
  dynamic "security_rule" {
    for_each = var.security_rules
    content {
      name                       = security_rule.value.name
      priority                   = security_rule.value.priority
      direction                  = security_rule.value.direction
      access                     = security_rule.value.access
      protocol                   = security_rule.value.protocol
      source_port_range          = security_rule.value.source_port_range
      destination_port_range     = security_rule.value.destination_port_range
      source_address_prefix      = security_rule.value.source_address_prefix
      destination_address_prefix = security_rule.value.destination_address_prefix
    }
  }
  tags = var.tags
}
resource "azurerm_network_interface" "network_interface" {
  name                = "nic-${var.project_name}-${var.location_abbreviation}-${format("%02d", var.virtual_machine_instance_number)}"
  location            = var.location
  resource_group_name = var.resource_group_name
  ip_configuration {
    name                          = "internal"
    subnet_id                     = var.subnet_id
    private_ip_address_allocation = "Static"
    public_ip_address_id          = azurerm_public_ip.public_ip.id
  }
  tags = var.tags
}
resource "azurerm_network_interface_security_group_association" "security_group_association" {
  network_interface_id       = azurerm_network_interface.network_interface.id
  network_security_group_id  = azurerm_network_security_group.security_group.id
}
/* ========================================
  Virtual Machines
======================================== */
resource "azurerm_linux_virtual_machine" "linux_virtual_machine" {
  name                            = "vm-${var.virtual_machine_context_description}-${format("%02d", var.virtual_machine_instance_number)}"
  resource_group_name             = var.resource_group_name
  location                        = var.location
  size                            = "Standard_B1s"
  admin_username                  = var.admin_username
  admin_password                  = var.disable_password_authentication == true ? null : var.admin_password
  disable_password_authentication = var.disable_password_authentication
  dynamic "admin_ssh_key" {
    for_each = var.disable_password_authentication == true ? [1] : []
    content {
      username   = var.admin_username
      public_key = file("~/.ssh/id_rsa.pub")
    }
  }
  network_interface_ids = [
    azurerm_network_interface.network_interface.id,
  ]
  os_disk {
    name                 = "osd-vm-${var.project_name}-${var.virtual_machine_context_description}-${var.location_abbreviation}-${format("%02d", var.virtual_machine_instance_number)}"
    caching              = "ReadWrite"
    storage_account_type = "Standard_LRS"
  }
  source_image_reference {
    publisher = "Canonical"
    offer     = "0001-com-ubuntu-server-focal"
    sku       = "20_04-lts-gen2"
    version   = "latest"
  }
  provisioner "remote-exec" {
    inline = [
      "sudo snap install terraform --classic"
    ]
    connection {
      type        = "ssh"
      host        = azurerm_public_ip.public_ip.ip_address
      user        = var.admin_username
      password    = var.admin_password
      private_key = null
    }
  }
  tags = var.tags
}