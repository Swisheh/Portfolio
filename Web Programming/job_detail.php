<?php
/*
 * Displays details of job with given id.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = @$_SESSION['username'];

$error = @$_GET['error']; # for error reporting

$id = $_GET['id'];
$job = get_job($id);

# Get the time until job ends
$enddate = new DateTime();
$enddate->setTimestamp(strtotime($job['enddate']));
$nowdate = new DateTime();
$nowdate->setTimestamp(time());
$diff = $nowdate->diff($enddate);

$smarty = new Smarty;

$smarty->assign("error",$error);
$smarty->assign("diff",$diff);
$smarty->assign("id",$id);
$smarty->assign("user",$user);
$smarty->assign("job",$job);
$smarty->display("job_detail.tpl");
?>
