import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class One {

    public static int solve(String line, int[] rgb) {
        String[] split = line.split(":");
        int id = Integer.parseInt(split[0].replace("Game ", ""));
        String[] games = split[1].split(";");

        for (String game : games) {
            String[] cubes = game.split(",");
            int[] currentRgb = new int[3];

            for (String cube : cubes) {
                String[] current = cube.split(" ");
                switch (current[2]) {
                    case "red":
                        currentRgb[0] = Integer.parseInt(current[1]);
                        break;
                    case "green":
                        currentRgb[1] = Integer.parseInt(current[1]);
                        break;
                    case "blue":
                        currentRgb[2] = Integer.parseInt(current[1]);   
                        break;
                    default:
                        break;
                }
            }
           
            for (int i = 0; i < 3; i++) {
                if (currentRgb[i] > rgb[i]) {
                    return 0;
                }
            }
        }
        
        return id;
    }


    
    public static void main(String[] args) {
        String path = "input.txt";
        int total = 0;
        int[] rgb = new int[]{12, 13, 14};

        try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
            String line;
            while ((line = reader.readLine()) != null) {
                total += solve(line, rgb);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        System.out.println(total);
    }
}