<?php
/*
 * Adds new job from form data.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = $_SESSION['username'];

# Get form data
$title = $_POST['title'];
$description = $_POST['description'];
$location = $_POST['location'];
$salary = $_POST['salary'];
$startD = strtotime($_POST['startD']);
$endD = strtotime($_POST['endD']);
$id = getId($user);


# Check data is valid
if (empty($title)) {
    $error = "title must be nonempty.";
    header("Location: job_list_employer.php?error=$error");
    exit;
}

# Check salary is an int
if (is_int($salary)){
	$error = "Must be positive integer.";
	header("Location: update_job?id=$id&error=$error");
	exit;
}

# Check location is valid
if (empty($location)) {
    $error = "Location must be nonempty.";
    header("Location: update_job?id=$id&error=$error");
    exit;
}

# add new job with form data
$id2 = add_job($id,$title,$description,$location,$salary,$startD,$endD);

header("Location: job_detail_employer.php?id=$id2"); 
exit;
?>
