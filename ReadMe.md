# Beyond Real Boilerplate

This repository is meant to be cloned and copied to a new repository. It provides a quick start for a new project. This boilerplate uses the Universal Render Pipeline (URP) which incorporates ShaderGraph. I plan to update this boilerplate with utility functions and other code that could be useful in future projects.

## Copy Instructions

* Clone this repository to a local directory named with the new project's name (The project name should not have any spaces in it) `git clone <repo-url> <project-name>`
* Enter the new directory and delete the ".git" folder
* Create a matching remote repository in github (or other remote repository space)
   * Default branch name is `main` (if an option)
   * No readme or any other files (should be empty)
* In the local repository, run the following commands
   * `git init`
      * If the default branch is something other than `main`, then run `git checkout -b main`
   * `git remote add origin <new-repo-url>`
   * `git add .`
   * `git commit -m "Initial clone of Beyond Real Boilerplate"`
   * `git push origin main`
* Check that the remote repository recieved the correct code

## Other Info

No other info at this time thanks.
