# output "virtual_machines_public_ips" {
#   value     = module.linux_virtual_machines[*].public_ip_address
#   sensitive = false
# }
output "virtual_machines_public_ips" {
  value = { for key in keys(module.linux_virtual_machines) : key => module.linux_virtual_machines[key].public_ip_address }
  sensitive = false
}