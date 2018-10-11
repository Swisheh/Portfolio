/*
 * 1. Create a JFrame with a JButton with title “Select Image...”. 
 * 2. When the user clicks the button display a JFileChooser open dialog to allow the user to select an image. 
 * 3. If the user chose an image, display it in the same window using an ImageIcon and a JLabel.
 * */

import javax.swing.*;
import java.util.*;

public class L282{

  public static void main (String[] args)
      {
    JFrame.setDefaultLookAndFeelDecorated(true);
    JFrame frame = new JFrame("Select Image...");
    JButton button = new JButton("Select Image...");
    
    frame.add(button);
    frame.setSize(300,200);
    button.setSize(50,200);
    frame.setVisible(true);
    
  }
}