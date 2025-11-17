# Connection Strings Configuration

This project now uses a local configuration file to manage connection strings, keeping sensitive data out of version control.

## Setup

1. **Configuration File**: The connection strings are stored in `connectionstrings.local.json` in the PowershellCommands folder.

2. **File Structure**: 
```json
{
  "ConnectionStrings": {
    "Maintenance": {
      "Local": "Data Source=localhost;...",
      "Staging": "Data Source=tcp:SqlCoreDevAGL.buildinglink.local,..."
    },
    "EventLog": {
      "Local": "host=localhost;Port=5432;...",
      "Dev": "host=development1-..., ..."
    }
  }
}
```

3. **Git Ignore**: The `connectionstrings.local.json` file is automatically excluded from version control via `.gitignore`.

## How It Works

- **ConfigurationService**: Reads connection strings from the local JSON file
- **Service Updates**: `MaintenanceApiService` and `EventLogApiService` now use the configuration service instead of hardcoded strings
- **Runtime Loading**: Configuration is loaded when the application starts

## Benefits

- ✅ Connection strings are not committed to version control
- ✅ Easy to maintain different environments (Local, Staging, Dev)
- ✅ Centralized configuration management
- ✅ No risk of accidentally committing sensitive data

## Usage

The application will automatically use the connection strings from the local configuration file. If you need to modify connection strings, update the `connectionstrings.local.json` file directly.

**Note**: Make sure to keep a backup of your `connectionstrings.local.json` file as it won't be tracked by git.