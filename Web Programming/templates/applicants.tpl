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
<h1>Applicant</h1>
<h2>{$app.realname}</h2>
<div style="width: 300px;">
<table>
<tr><td class="col2">Name: </td><td>{$app.realname}</td></tr>
<tr><td class="col2">Phone: </td><td>{$app.phone}</td></tr>
<tr><td class="col2">Details: </td><td>{$app.details}</td></tr>
<tr><td class="col2">Photo: </td><td><img src="get_photo.php?id={$app.realname}" 
	width="100" height="100" ></td></tr>
</table>
</div>

<h2>Application to job</h2>
<table>
<tr><td class="col2">Application Letter: </td><t</tr>
</table>
<div style="margin-left: 20px;">
<pre>{$app.letter}</pre>
</div>
<table>
<tr><td class="col2">Application Date: </td>
<td>{date('d/m/Y', strtotime($app.appdate))}</td></tr>
</table>

<p><a href="index.php">Home</a></p>
<hr>
Created by: Rory Hiscock <br>
</body>
</html>
