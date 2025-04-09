provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "golfpool_rg" {
  name     = "golfpool-resource-group"
  location = "East US"
}

resource "azurerm_app_service_plan" "golfpool_plan" {
  name                = "golfpool-app-service-plan"
  location            = azurerm_resource_group.golfpool_rg.location
  resource_group_name = azurerm_resource_group.golfpool_rg.name
  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "golfpool_app" {
  name                = "golfpool-app-service"
  location            = azurerm_resource_group.golfpool_rg.location
  resource_group_name = azurerm_resource_group.golfpool_rg.name
  app_service_plan_id = azurerm_app_service_plan.golfpool_plan.id

  site_config {
    dotnet_framework_version = "v6.0"
  }

  identity {
    type = "SystemAssigned"
  }
}

