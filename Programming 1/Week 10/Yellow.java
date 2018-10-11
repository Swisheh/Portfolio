// file: Yellow.java
// generated by: mashc
// from: Yellow.mash

public class Yellow extends Yellow$SUPER {

protected static final int MAX_INT = java.lang.Integer.MAX_VALUE;

protected static final int MIN_INT = java.lang.Integer.MIN_VALUE;

protected static final long MAX_LONG = java.lang.Long.MAX_VALUE;

protected static final long MIN_LONG = java.lang.Long.MIN_VALUE;

protected static final double PI = java.lang.Math.PI;

private static javax.swing.JFrame mash_graphics_frame = 
               new javax.swing.JFrame();

private static mash_graphics_Component mash_graphics_component = new mash_graphics_Component();

public static void mash_graphics_setUpFrame() 
            throws java.lang.Exception {
               mash_graphics_frame.setSize(300, 300);
               mash_graphics_frame.setTitle("Yellow");
               mash_graphics_frame.setDefaultCloseOperation(
                  javax.swing.JFrame.EXIT_ON_CLOSE);
               mash_graphics_frame.add(mash_graphics_component);
            }

private static java.awt.Graphics mash_graphics_g = null;

private static java.awt.Graphics2D mash_graphics_g2 = null;

private static java.awt.Image[] mash_graphics_images = 
               new java.awt.Image[10000];
            private static int mash_graphics_imageCount = 0;
            private static boolean mash_image_load_complete = false;

private static int mash_graphics_getImage(String path) {
               try {
                  mash_image_load_complete = false;
                  java.lang.String ext = "";
                  int i = path.length() -1;
                  while (i >= 0) {
                     char c = path.charAt(i);
                     if (c == '.') {
                        i = -1;
                     } else {
                        ext = c + ext;
                        i--;
                     }
                  }
                  java.io.FileInputStream fin = 
                     new java.io.FileInputStream(path);
                  java.util.Iterator readers = 
                     javax.imageio.ImageIO.getImageReadersBySuffix(ext);
                  javax.imageio.ImageReader ir = 
                     (javax.imageio.ImageReader) readers.next();
                  javax.imageio.stream.ImageInputStream iis = 
                     javax.imageio.ImageIO.createImageInputStream(fin);
                  ir.setInput(iis, false);
                  ir.addIIOReadProgressListener(
                     new javax.imageio.event.IIOReadProgressListener() {
                        public void imageComplete(
                           javax.imageio.ImageReader source) {
                           mash_image_load_complete = true;
                        }
                        public void imageProgress(
                           javax.imageio.ImageReader source, 
                           float percentageDone) { }
		        public void imageStarted(
		           javax.imageio.ImageReader source, int imageIndex) { }
		        public void readAborted(
		           javax.imageio.ImageReader source) { }
		        public void sequenceComplete(
		           javax.imageio.ImageReader source) { }
		        public void sequenceStarted(
		           javax.imageio.ImageReader source, int minIndex) { }
		        public void thumbnailComplete(
		           javax.imageio.ImageReader source) { }
		        public void thumbnailProgress(
		           javax.imageio.ImageReader source,
		           float percentageDone) { }
		        public void thumbnailStarted(
		           javax.imageio.ImageReader source, int imageIndex, 
	                   int thumbnailIndex) { }
                     }); 
                  mash_graphics_images[mash_graphics_imageCount++] = ir.read(0);
                  while (!mash_image_load_complete) {
                  }
                  return mash_graphics_imageCount - 1;
               } catch (java.lang.Exception e) {
                  java.lang.System.out.println("Could not read image file: "
                                               + path);
                  java.lang.System.out.println(e);
                  return -1;
               }
            }

private static java.util.Timer mash_graphics_timer = 
               new java.util.Timer();

private static java.util.TimerTask mash_graphics_task = 
               new java.util.TimerTask() {
                  public void run() {
                     
                     mash_graphics_component.repaint();
                  }
               };

private static java.applet.AudioClip[] mash_graphics_clips = 
               new java.applet.AudioClip[10000];
            private static int mash_graphics_clipCount = 0;

private static int mash_graphics_getSound(String url) {
               try {
                  mash_graphics_clips[mash_graphics_clipCount] = 
                     java.applet.Applet.newAudioClip(new java.net.URL(url)); 
                  mash_graphics_clipCount++;
                  return mash_graphics_clipCount - 1;
               } catch (java.lang.Exception e) {
                  java.lang.System.out.println("Could not read sound file: "
                                               + url);
                  java.lang.System.out.println(e);
                  return -1;
               }
            }

private static void mash_sleep(int ms) {
                try {
                   java.lang.Thread.sleep(ms);
                } catch (java.lang.Exception e) {
                }
             }

private static java.util.Scanner mash_console_scanner 
               = new java.util.Scanner(System.in);

public static void main(java.lang.String[] mash_args_param) 
         throws java.lang.Exception {
            mash_graphics_setUpFrame();
            
{
mash_graphics_frame.setSize(200, 220);
mash_graphics_frame.setVisible(true);
}

         }


private static class mash_graphics_Component 
            extends javax.swing.JComponent {
         
            public mash_graphics_Component() {
               super();
               addMouseListener(new java.awt.event.MouseListener() {
                     public void mouseClicked(java.awt.event.MouseEvent e) {
                        Yellow.mash_graphics_onMouseClicked(
                           e.getX(), e.getY());
                     }
                     public void mouseEntered(java.awt.event.MouseEvent e) {
                        Yellow.mash_graphics_onMouseEntered(
                           e.getX(), e.getY());
                     }
                     public void mouseExited(java.awt.event.MouseEvent e) {
                        Yellow.mash_graphics_onMouseExited(
                           e.getX(), e.getY());
                     }
                     public void mousePressed(java.awt.event.MouseEvent e) {
                        Yellow.mash_graphics_onMousePressed(
                           e.getX(), e.getY());
                     }
                     public void mouseReleased(java.awt.event.MouseEvent e) {
                        Yellow.mash_graphics_onMouseReleased(
                           e.getX(), e.getY());
                     }
                  });
               addKeyListener(new java.awt.event.KeyListener() {
                     public void keyPressed(java.awt.event.KeyEvent e) {
                        Yellow.mash_graphics_onKeyPressed(
                           e.getKeyCode());
                     }
                     public void keyReleased(java.awt.event.KeyEvent e) {
                        Yellow.mash_graphics_onKeyReleased(
                           e.getKeyCode());
                     }
                     public void keyTyped(java.awt.event.KeyEvent e) {
                        Yellow.mash_graphics_onKeyTyped(
                           e.getKeyChar());
                     }
                  });
            }
         
            public void paintComponent(java.awt.Graphics mash_graphics_g1) {
               super.paintComponent(mash_graphics_g1);
               mash_graphics_g = mash_graphics_g1;
               mash_graphics_g2 = (java.awt.Graphics2D) mash_graphics_g1;
               mash_graphics_g2.setRenderingHint(
                  java.awt.RenderingHints.KEY_ANTIALIASING, 
                  java.awt.RenderingHints.VALUE_ANTIALIAS_ON);
               mash_graphics_component.requestFocusInWindow();
               
{
mash_graphics_g2.setColor(
               new java.awt.Color(255, 255, 0));
mash_graphics_g2.fillOval(50, 50, 100, 100);
}

            } // method: paintComponent
            
         } // class: mash_graphics_Component

} // end of the program class
         
         class Yellow$SUPER {
         
            protected static void mash_graphics_onMouseClicked(int x, int y) {
            }
         
            protected static void mash_graphics_onMouseEntered(int x, int y) {
            }
         
            protected static void mash_graphics_onMouseExited(int x, int y) {
            }
         
            protected static void mash_graphics_onMousePressed(int x, int y) {
            }
         
            protected static void mash_graphics_onMouseReleased(int x, int y) {
            }
            
            protected static void mash_graphics_onKeyPressed(int code) {
            }
            
            protected static void mash_graphics_onKeyReleased(int code) {
            }
            
            protected static void mash_graphics_onKeyTyped(char c) {
            }
            
         } // end of superclass