# Password Manager

A simple console-based password manager built with C# 12 and .NET 8.

## Features

- List all saved passwords
- Add or change a password for a website/app
- Retrieve a password by website/app name
- Delete a password entry
- Passwords are stored in an encrypted format

## Usage

1. **Run the application**  
   Execute the program using your preferred method (e.g., `dotnet run`).

2. **Select an option**  
   - `1` - List all passwords  
   - `2` - Add/change password  
   - `3` - Get password  
   - `4` - Delete password  

3. **Follow prompts**  
   Enter the website/app name and password as requested.

## Data Storage

- Passwords are stored in `Passwords.txt` in the application directory.
- Each password is encrypted using the `Encryption_Utility` class.

## Requirements

- .NET 8 SDK or later

## Notes

- This application is for educational purposes and does not implement advanced security practices.
- Do not use for storing real or sensitive passwords.
