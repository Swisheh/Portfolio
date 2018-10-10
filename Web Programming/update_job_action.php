<?php
/*
 * Updates job from form job.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

# Get form job
$id = $_POST['id'];
$title = $_POST['title'];
$description = $_POST['description'];
$location = $_POST['location'];
$salary = $_POST['salary'];
$startD = strtotime($_POST['startD']);
$endD = strtotime($_POST['endD']);

# Check job is valid
if (empty($title)) {
    $error = "Title must be nonempty.";
    header("Location: update_job?id=$id&error=$error");
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

# Perform update with job
update_job($id,$title,$description,$location,$salary,$startD,$endD);

header("Location: job_detail_employer.php?id=$id"); 
exit;
?>


