<?php
/*
 * Updates job with given id.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = $_SESSION['username'];

$id = $_GET['id'];
$error = @$_GET['error']; # for error reporting

$job = get_job($id);

$smarty = new Smarty;
$smarty->assign('user',$user);
$smarty->assign('job',$job);
$smarty->assign('error',$error);

$smarty->display('update_job.tpl');
?>
