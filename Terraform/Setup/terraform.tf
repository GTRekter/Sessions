/* ========================================
  Locals
======================================== */
locals {
  project_name = "training"
  location_abbreviation = "eus"
  tags = {
    Application = "Server"
    Scope = "Training"
  }
  virtual_machines = [
    {
      name           = "student01",
      admin_username = "student01!",
      admin_password = "P@ssw0rd1234!"
    },
    {
      name           = "student02",
      admin_username = "student02!",
      admin_password = "P@ssw0rd1234!"
    }
  ]
}
/* ========================================
  Provider and Terraform Block
======================================== */
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>2.0"
    }
  }
}
provider "azurerm" {
  features {}
}
/* ========================================
  Resource Group
======================================== */
resource "azurerm_resource_group" "resource_group" {
    name     = "rg-${local.project_name}-${local.location_abbreviation}-01"
    location = "eastus"
    tags = local.tags
}

/* ========================================
  Networking
======================================== */
resource "azurerm_virtual_network" "virtual_network" {
  name                = "vnet-${local.project_name}-${local.location_abbreviation}-01"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  tags = local.tags
}
resource "azurerm_subnet" "subnet" {
  name                 = "snet-${local.project_name}-${local.location_abbreviation}-01"
  resource_group_name  = azurerm_resource_group.resource_group.name
  virtual_network_name = azurerm_virtual_network.virtual_network.name
  address_prefixes     = ["10.0.2.0/24"]
}
/* ========================================
  Virtual Machines
======================================== */
module "linux_virtual_machines" {
  for_each = { for virtual_machine in local.virtual_machines : virtual_machine.name => virtual_machine }

  source                              = "./modules/azurerm_linux_virtual_machine"
  location                            = azurerm_resource_group.resource_group.location
  resource_group_name                 = azurerm_resource_group.resource_group.name
  project_name                        = local.project_name
  location_abbreviation               = local.location_abbreviation
  virtual_machine_instance_number     = index(local.virtual_machines, each.value) + 1
  virtual_machine_context_description = "student"
  admin_username                      = each.value.admin_username
  admin_password                      = each.value.admin_password
  subnet_id                           = azurerm_subnet.subnet.id
  tags                                = local.tags
}