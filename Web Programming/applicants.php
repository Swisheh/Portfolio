<?php
/*
 * Checks applicants for job with given Id
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = $_SESSION['username'];

$applicant = $_GET['applicant'];

$app = get_app($applicant);

$smarty = new Smarty;
$smarty->assign('user',$user);
$smarty->assign('app',$app);

$smarty->display('applicants.tpl');
?>
