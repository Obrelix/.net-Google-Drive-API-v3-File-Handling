![alt tag](https://raw.githubusercontent.com/Obrelix/.net-Google-Drive-API-v3-File-Handling/master/images/pictureSample5.PNG)

![alt tag](https://raw.githubusercontent.com/Obrelix/.net-Google-Drive-API-v3-File-Handling/master/images/pictureSample6.PNG)

# .Net Google Drive API v3 file handling application

A Windows Forms Application writen in c# making use of Google Drive API V3.

# Features

Connects with multiple Google Drive and Google Calendar accounts.

Αccessing and processing all of the Google Drive Files and the Google Calendar's Events.

Uploading/Downloading/Deleting Google Drive files and directories .

Searching for files in Google Drive with file name and type parameters. 

Validating via Md5 Checksum hash, on the loading sequence, in order to avoid the creation of duplicate files.

Auto Creating scripts (Batch files) for scheduled uploads via Windows Scheduler.

Running as a background console application when it starts with arguments.

Downloading/Uploading asynchronous.

# Upcomming

Uploading files with Google Calendar specific Events.

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
