# data "azurerm_public_ip" "pips" {
#   for_each            = toset(module.linux_virtual_machines.public_ip_names)
#   name                = each.value
#   resource_group_name = azurerm_resource_group.resource_group.name
# }