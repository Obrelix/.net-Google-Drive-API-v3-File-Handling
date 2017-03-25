![alt tag](https://raw.githubusercontent.com/Obrelix/.net-Google-Drive-API-v3-File-Handling/master/images/pictureSample5.PNG)

![alt tag](https://raw.githubusercontent.com/Obrelix/.net-Google-Drive-API-v3-File-Handling/master/images/pictureSample6.PNG)

# .Net Google Drive API v3 file handling application

A Windows Forms Application writen in c# making use of Google Drive API V3.

# Features

Connects to multiple google drive accounts

Previewing in a data grid view the Google Drive Files

Uploading files to Google Drive

Uploading directories with subdirectories to Drive

Downloading files from Google Drive

Deleting files from Goolge Drive

Searching files in Google Drive

Generating the Md5 Checksum hash for the uploading files in order to compare it with the hash of google drive files and warning the user that the file already exist in the Drive.

Creating a Batch file for the upload, to add it in Windows Scheduler and run the application with arguments.

Running as a background console application when you start the application with arguments 

# Upcomming

Downloading/Uploading asynchronous


# Instrunctions

In order to use this Application you have 

Start the application and:

1)Check the checkbox "add user"

2)Type your name for your profile

3)Click on "save user" button to save your user profile

4)Select your profile from the combobox.

5)Click on "Connect to Google Drive" Button to open a connection.

6)The first time you connect to a user profile, a browser window will appear asking you to connect to your Google account.

7)Connect and approve the Google notification.

8)In order to connect to an other account repeat the previous sequence.

If you want to use your own client you have to follow the First step from this tutorial https://developers.google.com/drive/v3/web/quickstart/dotnet

When you have already created an "OAuth 2.0 client" and downloaded the client_secret.Json file from https://console.developers.google.com Add your clien_secret.Json file.
