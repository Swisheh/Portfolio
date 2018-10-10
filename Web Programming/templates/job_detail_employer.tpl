<!DOCTYPE HTML>
<html>
<head>
{if $user}
	{include 'header.tpl' title="Job List" user="Logged in as: $user"}
{else}
	{include 'header.tpl' title="Home page"}
{/if}
</head>

<body>
<h1>Employer Site</h2>
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
</table>

{if $check}
	{if $apps}
		<h2>List of Applicants</h2>
		<table>
		{foreach $apps as $app}
		<tr>
			<td class="col2"><a href="applicants.php?applicant={$app.applicant}">
			{$app.applicant|escape}</a></td>
		</tr>
		{/foreach}
		</table>
	{else}
		<p>No applicants found.</p>
	{/if}
	<br>
	<p><a href="update_job.php?id={$job.id}">Update this job</a>
	<p><a href="delete_job_action.php?id={$job.id}">Delete this job</a>
{/if}
<p><a href="index.php">Home</a></p>

<hr>
	Created by: Rory Hiscock <br>


</body>
</html>
