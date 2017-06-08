<?php include 'includes/head.php';?>

<div class="left">
  <form id="ShipForm" action="order.php" method="post">
    <table class="tg">
     <?php
      session_start();
      $ShipsArray = $_SESSION["ShipsArray"];
      if(!isset($_SESSION['Ship'])){
        $_SESSION['Ship'] = null;
      }
      if(isset($_POST['btnShip']) AND $_SESSION['Ship'] != $_POST['btnShip']){
        unset($_SESSION['Ship']);
        $_SESSION['Ship'] = $_POST['btnShip'];
      }
      //print_r($ShipsArray);
      foreach ($ShipsArray as $key => $Ship){
        if($Ship['ShipID'] == $_SESSION["Ship"]){
          echo '
          <input type="hidden" name="ShipID" value="' . $Ship['ShipID'] . '">
          <tr>
            <th class="tg-031e"><p>Name:</p></th>
            <th class="tg-yw4l"><p>' . $Ship['Name'] . '</p><input type="hidden" name="Name" value="' . $Ship['Name'] . '"></th>
          </tr>
          <tr>
            <td class="tg-031e"><p>Price:</p></td>
            <td class="tg-b7b8"><p>' . $Ship['Price'] . '</p></td>
          </tr>
          <tr>
            <td class="tg-031e"><p>Date of mod:</p></td>
            <td class="tg-b7b8"><p>' . $Ship['DateOfModification'] . '</p></td>
          </tr>
          <tr>
            <td class="tg-yw4l"><p>Stock:</p></td>
            <td class="tg-b7b8"><p>' . $Ship['StockQuanitiy'] . '</p><input type="hidden" name="StockQuanitiy" value="' . $Ship['StockQuanitiy'] . '"></td>
          </tr>';

          if ($Ship['$type'] == 'AdminApp.clsCruiser, AdminApp'){
            echo'
            <tr>
              <td class="tg-yw4l"><p>Torpedo tubes:</p></td>
              <td class="tg-b7b8"><p>' . $Ship['TorpedoTubeCount'] . '</p></td>
            </tr>
            <tr>
              <td class="tg-yw4l"><p>Plane type:</p></td>
              <td class="tg-b7b8"><p>' . $Ship['PlaneType'] . '</p></td>
            </tr>';
          }else {
            echo'
            <tr>
              <td class="tg-yw4l"><p>Torpedo belt%:</p></td>
              <td class="tg-b7b8"><p>' . $Ship['TorpedoBulge'] . '</p></td>
            </tr>
            <tr>
              <td class="tg-yw4l"><p>Heal:</p></td>
              <td class="tg-b7b8"><p>' . $Ship['HealAmount'] . '</p></td>
            </tr>';
          }
        }
      }?>

      <?php
      echo'
      <button name="btnShip" type="submit" value="submit" class="button view" style="vertical-align:middle"><span>Buy</span></button>'; ?>
    </table>
  </form>
  <a href="ships.php" class="buttonback"><p>Back</p></a>
</div>


<?php include 'includes/foot.php';














?>
