<!DOCTYPE HTML>
<html>
<head>
{if $user}
	{include 'header.tpl' title="Job list" user="Logged in as: $user"}
{else}
	{include 'header.tpl' title="Home page"}
{/if}
</head>

<body>
<h1>Update job</h1>
{if $error}
    <p>{$error}</p>
{/if}

<form method="post" action="update_job_action.php">
    <input type="hidden" name="id" value="{$job.id}">
    <table>
    <tr><td class="col2">Title:</td> <td><input type="text" name="title" 
	value="{$job.title}"> <br></td></tr>
    <tr><td class="col2">Description:</td> <td><textarea 
	name="description">{$job.description}</textarea> <br></td></tr>
	<tr><td class="col2">Location:</td> <td><input type="text" name="location" 
	value="{$job.location}"> <br></td></tr>
	<tr><td class="col2">Salary:</td> <td><input type="number" name="salary" 
	value="{intval($job.salary)}"> <br></td></tr>
	<tr><td class="col2">Application Start Date:</td> <td><input type="text" name="startD" 
	value="{date('d/m/Y', strtotime($job.startdate))}"></td></tr>
	<tr><td class="col2">Application End Date:</td> <td><input type="text" name="endD" 
	value="{date('d/m/Y', strtotime($job.enddate))}"></td></tr>
    <tr><td><input type="submit" value="Update job"></td></tr>
    </table>
</form>

<p><a href="index.php">Home</a></p>
<hr>
Created by: Rory Hiscock <br>
</body>
</html>
