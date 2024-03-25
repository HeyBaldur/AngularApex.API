# AngularApex.API

## Step-by-Step Guide to Run an ASP.NET Core API with `dotnet watch run`

### 1. Install .NET SDK:
   - Ensure you have the .NET SDK installed on your machine. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).

### 2. Clone the ASP.NET Core API Project:
   - Open a terminal or command prompt.
   - Navigate to the directory where you want to clone the project.
   - Run the following command to clone the project from the repository:
     ```
     git clone https://github.com/HeyBaldur/AngularApex.API.git
     ```
   Replace `<repository-url>` with the URL of the Git repository where the ASP.NET Core API project is hosted.

### 3. Navigate to the Project Directory:
   - Use the `cd` command to navigate into the cloned project directory:
     ```
     cd <project-directory>
     ```
   Replace `<project-directory>` with the name of the directory created after cloning the repository.

### 4. Restore Dependencies:
   - Run the following command to restore the project dependencies:
     ```
     dotnet restore
     ```

### 5. Build the Project:
   - Build the project using the following command:
     ```
     dotnet build
     ```

### 6. Run the Project with `dotnet watch run`:
   - Once the build process completes successfully, you can start the project with `dotnet watch run`. This command will automatically restart the application when changes are detected in the source code files.
     ```
     dotnet watch run
     ```

### 7. Access the API:
   - Once the application has started, you can access the API endpoints using a web browser or API testing tool. By default, the API will be accessible at `https://localhost:5001` (or `http://localhost:5000`).
