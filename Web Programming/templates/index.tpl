<!DOCTYPE HTML>
<html>
<head>
{if $user}
	{include 'header.tpl' title="Home page" user="Logged in as: $user"}
{else}
	{include 'header.tpl' title="Home page"}
{/if}

<script language="javascript" type="text/javascript">		
		function validateForm(){
			var errorM = "";
			var ifTrue = true;
			// Check valid email
			var x=document.forms["register"]["email"].value;
			var atpos=x.indexOf("@");
			var dotpos=x.lastIndexOf(".");
			if (atpos<1 || dotpos<atpos+2 || dotpos+2>=x.length){
				errorM += "Not a valid e-mail address ";
				ifTrue = false;
			}
			
			// Check password is not empty
			var y=document.forms["register"]["password"].value;
			if (y==null || y==""){
				errorM += "Password must not be empty! ";
				ifTrue = false;
			}
			
			// Check name not empty
			var y=document.forms["register"]["name"].value;
			if (y==null || y==""){
				errorM += "Name must not be empty! ";
				ifTrue = false;
			}
			
			// Check phone number not empty
			var y=document.forms["register"]["phone"].value;
			if (y==null || y==""){
				errorM += "Phone number must not be empty! ";
				ifTrue = false;
			}
			
			// If any elements above are false it'll print the errors
			if (!ifTrue){
				alert(errorM);
				return ifTrue;
			}
		}
</script>
</head>

<body>
<h1>Browse Jobs</h1>
{if $permission > 1}
<p><a href="job_list_employer.php">Show all jobs</a></p>
{else}
<p><a href="job_list.php">Show all jobs</a></p>
{/if}

{if $permission || $permission == 2}
	
	<form name="updatepassword" method="post" action="index.php">
	<table>
	<th>Update Passord</th>
	<tr><td class="col2">Current Password: </td><td><input type="password" name="currentP"></tr></td>
	<tr><td class="col2">New Password: </td><td><input type="password" name="newP"></tr></td>
	<tr><td class="col2">Confirm New Password: </td><td><input type="password" name="new2P"></tr></td>
	<tr><td><input type="submit" name="submit" value="Update"></td></tr>
	</table>
	</form>
	
	<form name="logout" method="post" action="index.php">
	<input type="hidden" value="logout" name="logout"><br>
	<input type="submit" name="submit" value="Logout!">
	</form>
	<br>
	
{else}

  <form name="login" method="post" action="index.php">
  <table>
  <th>Login </th>
   <tr><td class="col2" >Email: </td><td><input type="text" name="username"></td></tr>
   <tr><td class="col2" >Password: </td><td><input type="password" name="password"></td></tr>
   <tr><td><input type="submit" name="submit" value="Login!"></td></tr>
   </table>
  </form>
  <br>
  
  <form name="register" method="post" action="index.php" enctype="multipart/form-data" 
  onSubmit="return validateForm();">
  <table>
  <th>Register</th>
   <tr><td class="col2" >Email: </td><td><input type="text" name="email"></td></tr>
   <tr><td class="col2" >Password: </td><td><input type="password" name="Rpassword"></td></tr>
   <tr><td class="col2" >Name: </td><td><input type="text" name="name"></td></tr>
   <tr><td class="col2" >Phone: </td><td><input type="text" name="phone"></td></tr>
   <tr><td class="col2" >Photo: </td><td><input type="file" name="photo"></td></tr>
   <tr><td class="col2" >Other info: </td><td><input type="text" name="details"></td></tr>
   <tr><td><input type="submit" name="submit" value="Register!"></td></tr>
  </table>
  </form>
{/if}
	<hr>
Created by: Rory Hiscock <br>
</body>
</html>
