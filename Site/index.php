<?php
  error_reporting(0);
  session_start();
  include 'includes/head.php';
?>

<form id="NationsForm" action="ships.php" method="post">
  <table class="tg" id="Nations">
    <table class="tg">
      <tr>
        <th class="tg-031e"><p>Nation</p></th>
        <th class="tg-yw4l"></th>
      </tr>
      <?php
      //print_r($_SESSION);
      $Nations = $_SESSION["NationsArray"];
      foreach ($Nations as $key => $Nation){
        echo
        '<tr>
          <td class="tg-031e"><p>' . $Nation['Name'] . '</p></td>
          <td class="tg-b7b8"><button name="btnNation" id="ShipsButton" class="button view" style="vertical-align:middle" value="' . $Nation['NationID'] . '"><span>View</span></button></td>
        </tr>';
      } ?>
    </table>
  </table>
</form>


<?php include 'includes/foot.php';?>
