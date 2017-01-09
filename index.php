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
			<?php
				$test = $db->SelectAllFromTable('category', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					$products = $db->SelectAllFromTable('fridge', '', 'JOIN product ON fridge.Product=product.ID WHERE ' . $test[$i]->ID . '=product.Category');
					if(empty($products))
					{
						echo '<div id="category"><h1>' . ' (' . $test[$i]->ID . ') ' . $test[$i]->Name . '</h1><h2>0 Items</h2></div>';
					}
					else
					{
						echo '<div id="category"><div id="sub"><h1>' . ' (' . $test[$i]->ID . ') ' . $test[$i]->Name . '</h1><h2>' . count($products) . ' Items</h2></div></div>';
					}
					if(!empty($products))
					{
						for ($j = 0; $j < count($products); $j++) 
						{
							$product = $db->SelectAllFromTable('product', '', 'JOIN fridge ON product.ID=fridge.Product WHERE ' . $products[$j]->Product . '=product.ID');
							
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
							if($timeleft < 0)
							{
								$timeleft = 'EXPIRED';
							}
							else
							{
								$timeleft = 'Expires in: ' . $timeleft . ' days';
							}
							
							echo '<div id="product"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
						}
					}
				}
				?>
        </main>
    </body>
</html>