<?php include 'includes/head.php';?>
<h3>Your order</h3>
<br>
<form id="OrderForm" action="submit.php" method="post">
  <p>Name:</p>
  <input type="text" name="UserName" required>
  <p>Email:</p>
  <input type="email" name="Email" required>
  <p>Name:</p>
  <?php echo'
  <input type="hidden" name="ShipID" value="' . $_POST['ShipID'] . '">
  <p>' . $_POST["Name"] . '</p>
  <input type="hidden" name="ShipName" value="' . $_POST['Name'] . '">
  <p>Quantity:</p>
  <input name="Quantity" class="input" type="number" min="1" max="' . $_POST["StockQuanitiy"] . '" step="1" value ="1"/>
  '; ?>
  <br />
  <?php echo '
  <button name="btnShip" type="submit" value="submit" class="button view" style="vertical-align:middle"><span>Submit</span></button>
  '; ?>
  <a href="ship.php" class="buttonback"><p>Cancel order</p></a>
</form>
<?php include 'includes/foot.php';?>
