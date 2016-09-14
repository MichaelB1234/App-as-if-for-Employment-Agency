# App-as-if-for-Employment-Agency
Upload Candidate Details Functionality Only
Allows [recruitment agent] to add candidates files, supposedly cv, picture, allowed docs by popi act coming in, to database, and retrieve
files from database There is some code to allow for jpg, png, gif and pdf word excel - see handler.ashx and default.aspx.cs.
The main page where everything is happening is default.aspx
and default.aspx.cs - handler retrieves from sql and default saves to sql. Default uses handler
to read.
Main power of app is ability to upload to Microsoft Sequel Server and retrieving from Microsoft Sequel Server with use of varbinary(max)
(binary files).
Secondary power of app is advanced use of Gridview to store these files on a row by row method.
Am going to upload mostly blank database, it does test to work to add rows to gridview and add additional files.
What does not work is the red checkbox and text items
to delete an uploaded file, when you check and click apply it does I don't know what, since there is no code
for this latest add yet.
There is also a corny feature if you upload a picture of yourself and have named it Me.jpg this will be retrieved from the database and
be displayed as a background picture.
