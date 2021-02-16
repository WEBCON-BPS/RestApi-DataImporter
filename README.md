# RestApi-DataImporter

WebCon.Bps.Importer

Please note that this is just a sample application, delivered under attached license.

The application uses Excel and the public WEBCON REST API to import/export data between WEBCON BPS environments.

A REST API account is required for the program to work correctly. Creating such an account is described here: https://developer.webcon.com/docs/registration-and-authentiaction/

Additionally, the application uses an external Aspose.Cells component, an appropriate license will also be required for it work correctly. Without a license, we will be able to use the demo version. The license file must be added to the project, then set the build action in its properties as embedded resource. Such a license must be assigned in the constructor of the ImporterMainForm class, an example in comments is already found there.

Launch the program and fill out the authentication section. Enter the Portal URL, ClientID and secret of the REST application we want to use and the ID of the database we want to operate on. If we want to query the API as another user, we can also enter their UPN in the impersonation field.

Then select the application from the drop-down list, it will be used for import. If a specific application is not displayed, make sure that the account we used has the necessary privileges to access it.

It’s easiest to start with exporting. For this purpose, we need to configure a report with data that we want exported. Attachments and item lists can be omitted from the report - they can be included directly via the program. Provide the ID of the report configured in the application selected above, we can select a specific view. Page and size allow you to specify the amount of data to be downloaded - size determines the number of rows to be exported, while page allows us to split the export into parts or skip the first rows. We can also select item list values for export from the workflow instance, as well as attachments. In the case of the latter we must additionally select the folder to which they will be saved. Please note that both of these options will extend the export duration.

The export result should be an Excel file, each row in the sheet corresponds to a workflow Instance from the report, and each column to a form field. If we selected to export attachments, in the last column we will get the file paths. Multiple files will be separated by a semicolon. When exporting item lists, we will get additional an sheet for each item list. A list sheet contains information about configured columns, list values, and a Relation ID that references values on the main sheet.

In the next tab, we can generate an Excel file template that we can use for import. Enter the ID of the form type and the step for which information about form fields will be loaded. As a result, we will get an Excel file containing information about available fields in the headers, columns for attachments and Item lists, (along with additional sheets for each list). The generated template can be filled with data and used for import.

The last tab allows us to import data from Excel to the system. Importing has three operating modes:
•Launching instances - we provide the ID of the form type and ID of the workflow. Additionally we can provide the Path ID for the stared instance to take. If the field is left blank, the ID will be taken either from the file or the default path will be used.
•Instance update - For updating, Excel must contain the WFDID header column. The ID of the workflow instances to be updated will be retrieved from this column. If we specified a path or there is a PATHID column in the file, the instances will go along the given path. Otherwise, they will only be saved with the new data.
•Dynamic mode - based on entered data and file columns, the program will choose between: start, update or path transition.

In this tab, we can additionally configure how many instances will be imported simultaneously. We must select the Excel file to be imported, and also select the main worksheet containing data. If the file contains an attachment column with valid file paths, the files will be added to the appropriate workflow instances as attachments. The same applies to item lists. The main worksheet must contain a list column, and that row must reference rows on another worksheet via Relation ID.
