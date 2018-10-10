<?php
/*
 * Displays details of job with given id.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = $_SESSION['username'];

$id = $_GET['id'];
$job = get_job($id);
$id2 = getId($user);
$check = 0;
if($id2 == $job['employerId']){
	$check = 1;
}

# Get the time until job ends
$enddate = new DateTime();
$enddate->setTimestamp(strtotime($job['enddate']));
$nowdate = new DateTime();
$nowdate->setTimestamp(time());
$diff = $nowdate->diff($enddate);

$apps = get_apps($id);

$smarty = new Smarty;

$smarty->assign("apps",$apps);
$smarty->assign("diff",$diff);
$smarty->assign("user",$user);
$smarty->assign("job",$job);
$smarty->assign("check",$check);
$smarty->display("job_detail_employer.tpl");
?>
