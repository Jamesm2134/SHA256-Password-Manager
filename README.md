# SHA256-Password-Manager
A password manager using SHA-256 securely stores user passwords, accessible only with a master key. SHA-256 generates a unique, irreversible 256-bit hash for each password. The program stores hashed data and returns passwords only when the correct master key is provided.

# HOW IT WORKS

When the program is started, You are prompted with this menu
<img width="981" alt="begin" src="https://github.com/user-attachments/assets/6b9410d7-b360-4a33-91e3-8c9c3845d98d" />
To store a password, click 1 and enter the password you want to store
<img width="987" alt="enterpassword" src="https://github.com/user-attachments/assets/ca61e748-3891-410f-b3bd-97a6e0fea056" />
The password is then ran through the hash function and returns a masterkey to the user for ater retrieval of the password
<img width="980" alt="2test" src="https://github.com/user-attachments/assets/dae3ac44-db5b-4451-ab28-045511c3bbcf" />
If the user enters the wrong masterkey when trying to retieve the password, they will be prompted with this message and told to try again
<img width="982" alt="2failtest" src="https://github.com/user-attachments/assets/48986786-606b-4ce4-ace4-dc3953a46464" />
After each password it entered, the prgram stores the hashed password in a txt file. This is where the user can see if the password was entered correctly. The user is also prompted with the option to clear the txt file and dictionary where the passwords are stored.
<img width="470" alt="haaa" src="https://github.com/user-attachments/assets/43679500-8286-40b7-859c-f4eb2d975962" />
Finally, if the user clicks 4 the program will exit!
<img width="976" alt="exit" src="https://github.com/user-attachments/assets/712b6982-0618-48ba-844c-157a2f557c25" />
