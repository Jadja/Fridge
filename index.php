<?php
require_once('init.php');
?>
<doctype html>

<html>
    <head>
        <title>Fridge Thing</title>
        <meta charset="windows-1252">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="shortcut icon" href="favicon.ico">
        <link rel='stylesheet' href="assets/css/style.css" type="text/css" <!--media='screen and (min-width: 0px) and (max-width: 1700px)'--> />
    </head>
    <body>
        <main>
            <p>hello
            <?php
            echo SelectFirstFromTable('category', '', '')['Name'];
            ?>
            </p>
        </main>
    </body>
</html>