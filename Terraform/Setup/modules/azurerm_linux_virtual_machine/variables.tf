/* ========================================
  Naming Convention
======================================== */
variable "project_name" {
    description = "The name of the project"
    type        = string
    default     = "terraform"
}
variable "location_abbreviation" {
    description = "The location abbreviation"
    type        = string
    default     = "eus"
}
variable "virtual_machine_context_description" {
    description = "The description of the virtual machine context"
    type        = string
    default     = "sample"
    validation {
        condition     = can(regex("^.{0,8}$", var.virtual_machine_context_description))
        error_message = "The virtual machine context description must be less than 8 charachters"
    }
}
variable "virtual_machine_instance_number" {
    description = "The instance number of the virtual machine"
    type        = number
    default     = 1
    validation {
        condition     = can(regex("^[0-9]{1,2}$", var.virtual_machine_instance_number))
        error_message = "The virtual machine instance number must be a number between 1 and 99"
    }
}
/* ========================================
  Authentication
======================================== */
variable "admin_username" {
    description = "The admin username"
    type        = string
    default     = "azureuser"
    # validation {
    #     condition     = can(regex("^[a-z][a-z0-9]{0,29}$", var.admin_username))
    #     error_message = "The admin username must be a valid Azure username"
    # }
}
variable "admin_password" {
    description = "The admin password"
    type        = string
    # validation {
    #     condition     = can(regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+])(?=.{12,})$", var.admin_password))
    #     error_message = "The admin password must be a valid Azure password"
    # }
}
variable "disable_password_authentication" {
    description = "Disable password authentication"
    type        = bool
    default     = false
}
variable "security_rules" {
  description = "List of security rules"
  type = list(object({
    name                       = string
    priority                   = number
    direction                  = string
    access                     = string
    protocol                   = string
    source_port_range          = string
    destination_port_range     = string
    source_address_prefix      = string
    destination_address_prefix = string
  }))
  default = [{
    name                       = "SSH"
    priority                   = 300
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "22"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }]
}
/* ========================================
  Mandatory parameters
======================================== */
variable "location" {
    description = "The location"
    type        = string
    default     = "eastus"
    validation {
        condition     = can(regex("^(eastus|westus|westeurope|northeurope)$", var.location))
        error_message = "The location abbreviation must be a valid Azure location abbreviation"
    }
}
variable "resource_group_name" {
    description = "The resource group name"
    type        = string
}
/* ========================================
  Networking
======================================== */
variable "subnet_id" {
    description = "The subnet ID"
    type        = string
    validation {
        condition     = can(regex("^/subscriptions/[a-z0-9-]{36}/resourceGroups/[a-z0-9-]{1,64}/providers/Microsoft.Network/virtualNetworks/[a-z0-9-]{1,64}/subnets/[a-z0-9-]{1,64}$", var.subnet_id))
        error_message = "The subnet ID must be a valid Azure subnet ID"
    }
}
/* ========================================
  Tags
======================================== */
variable "tags" {
    description = "The tags"
    type        = map(string)
    validation {
        condition     = can(regex("^.{0,512}$", jsonencode(var.tags)))
        error_message = "The tags must be less than 512 charachters"
    }
}