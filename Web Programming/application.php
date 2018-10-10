<?php
/*
 * Adds new application from form data.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

$name = getname($_POST['user']);
$job = $_POST['id'];
$letter = $_POST['letter'];
$time = time();

# Check if already applied
if (applied($name)) {
    $error = "You have already applied for this job!";
    header("Location: job_detail.php?id=$job&error=$error");
    exit;
}

# add new application with form data
add_app($name, $job, $letter, $time);


header("Location: job_detail.php?id=$job"); 
exit;
?>
