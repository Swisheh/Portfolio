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
{if $error}
	<p>{$error}</p>
{/if}

<h1>User Site</h2>
<h2>{$job.title}</h2>
<table>    
<tr><td class="col2">Employer: </td><td>{$job.name}</td></tr>
<tr><td class="col2">Description: </td><td>{$job.description}</td></tr>
<tr><td class="col2">Location: </td><td>{$job.location}</td></tr>
<tr><td class="col2">Salary: </td><td>${$job.salary}</td></tr>
<tr><td class="col2">Application Start Date: </td>
<td>{date('d/m/Y', strtotime($job.startdate))}</td></tr>
<tr><td class="col2">Application End Date: </td>
<td>{date('d/m/Y', strtotime($job.enddate))}</td></tr>
<tr><td class="col2">Time Remaining: </td>
<td>{$diff->y}Years, {$diff->m}Months, {$diff->d}Days</td></tr>
</table><br>

{if $user}
<form name="register" method="post" action="application.php">
  <table>
  <th>Apply Here</th>
  <input type="hidden" name="id" value="{$id}">
  <input type="hidden" name="user" value="{$user}">
   <tr><td class="col2">Application Letter:</td> <td><textarea name="letter"></textarea></td></tr>
   <tr><td><input type="submit" name="submit" value="Apply Now!"></td></tr>
  </table>
</form><br>
{else}
<p>Must be signed in to apply!</p>
{/if}

<p><a href="index.php">Home</a></p>
<hr>
Created by: Rory Hiscock <br>
</body>
</html>
