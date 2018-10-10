<?php
/*
	Login Form
 */
require "Smarty.class.php";
require "includes/defs.php";

session_start();
# Set default user
$user = "Guest";

# Update password
if(isset($_POST['currentP']) AND isset($_POST['newP'])
	AND isset($_POST['new2P'])){
	$user = $_SESSION['username'];
	$currentP = $_POST['currentP'];
	$newP = $_POST['newP'];
	$new2P = $_POST['new2P'];
	if ($newP != $new2P){
		echo 'New password does not match!';
	} else {
		$check = checkPass($user,$currentP);
		if ($check){
			updatePass($user,$newP);
			echo 'Password updated!';
		} else {
			echo 'Current password does not match!';
		}
	}
}

# Logout 
if (isset($_POST['logout'])) {
	session_destroy();
	echo 'You have successfully logged out!';
	session_start();
	$_SESSION['permission'] = 0;
	$permission = $_SESSION['permission'];

# Check if registration form is filled
} else if (isset($_POST['email']) AND isset($_POST['Rpassword'])
			AND isset($_POST['name']) AND isset($_POST['phone'])) {
	$email = $_POST['email'];
	$Rpassword = $_POST['Rpassword'];
	$name = $_POST['name'];
	$phone = $_POST['phone'];
	$photo = $_FILES['photo'];
	$details = $_POST['details'];
	add_user($email,$Rpassword,$name,$phone,$photo,$details);
	$login = login($email,$Rpassword);
	$_SESSION['username'] = $email;
	$_SESSION['permission'] = $login;
	$permission = $_SESSION['permission'];
	$user = $_SESSION['username'];

# Check if a user is already logged in
} else if (isset($_SESSION['username'])){
	$user = $_SESSION['username'];
	$permission = $_SESSION['permission'];

# Check if login form is filled
} else if (isset($_POST['username']) AND isset($_POST['password'])) {
	$permission = 0;
	$username = $_POST['username'];
	$password = $_POST['password'];
	$login = login($username,$password);
	if($login) {
		$_SESSION['username'] = $username;
		$_SESSION['permission'] = $login;
		$permission = $_SESSION['permission'];
		$user = $_SESSION['username'];
	} else {
		echo 'Login Failed';
	}
	
# Set permission to 0 if noone is logged on
} else {
	$_SESSION['permission'] = 0;
	$permission = $_SESSION['permission'];
}


$smarty = new Smarty;

$smarty->assign("user", $user);
$smarty->assign("permission", $permission);
$smarty->display("index.tpl");
?>
