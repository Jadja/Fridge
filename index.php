<?php
require_once('init.php');
?>
<doctype html>

<html>
    <head>
        <title>Fridge Thing</title>
        <meta charset='utf-8'>
        <link rel='shortcut icon' href='favicon.ico'>
        <link rel='stylesheet' href='assets/css/style.css' type='text/css' />
        <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js'></script>
        <script src='assets/javascript/nav.js'></script>
    </head>
    <body>
        <main>
            <nav>
                <ul>
                </ul>
            </nav>
            <p>
            <?php
            /*$test = $db->SelectAllFromTable('category', '', '');
            for ($i = 0; $i < count($test); $i++) {
                echo $test[$i]->Name . '<br />';
            }*/
            ?>
            </p>
        </main>
    </body>
</html>