<?php
require_once('init.php');
?>
<doctype html>

<html>
    <head>
        <title>Food Thing</title>
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
			<?php
				$test = $db->SelectAllFromTable('category', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					$products = $db->SelectAllFromTable('food', '', "JOIN product ON food.Product=product.ID WHERE product.Category='" . $test[$i]->Name . "'");
					if(empty($products))
					{
						echo '<div id="category"><div id="sub"><h1>' . $test[$i]->Name . '</h1><h2>0 Items</h2></div></div>';
					}
					else
					{
						echo '<div id="category"><div id="sub"><h1>' . $test[$i]->Name . '</h1><h2>' . count($products) . ' Items</h2></div></div>';
					}
					if(!empty($products))
					{
						for ($j = 0; $j < count($products); $j++) 
						{
							$product = $db->SelectAllFromTable('product', '', 'JOIN food ON product.ID=food.Product WHERE ' . $products[$j]->Product . '=product.ID');
							
							$description = $products[$j]->Description;
							if(strlen($products[$j]->Description) > 50)
							{
							$description = substr($description, 0, 50);
							$description .= '...';
							}
							
							$now = time();
							$date = strtotime($products[$j]->Add_date);
							
							$diff = $now - $date;
							
							$timeleft = $product[0]->Expiration_time - (floor($diff / (60 * 60 * 24)));
							$divcolor = ($timeleft) / 5;
							if($timeleft < 0)
							{
								$timeleft = 'EXPIRED';
							}
							else
							{
								$timeleft = 'Expires In: ' . $timeleft . ' Days';
							}
							if($divcolor < 0)
							{
								$divcolor = 0;
							}
							
							switch (ceil($divcolor))
							{
								case 0:
									echo '<div id="product" style="background-color:red"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 1:
									echo '<div id="product" style="background-color:orange"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 2:
									echo '<div id="product" style="background-color:yellow"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 3:
									echo '<div id="product" style="background-color:lightgreen"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 4:
									echo '<div id="product" style="background-color:green"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								default:
									echo '<div id="product" style="background-color:darkgreen"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
							}
							
						}
					}
				}
				?>
        </main>
    </body>
</html>