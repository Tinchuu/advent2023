import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class Two {

    public static int solve(String line, int[] rgb) {
        String[] split = line.split(":");
        int id = Integer.parseInt(split[0].replace("Game ", ""));
        String[] games = split[1].split(";");
        int[] currentRgb = new int[3];

        for (String game : games) {
            String[] cubes = game.split(",");

            for (String cube : cubes) {
                String[] current = cube.split(" ");
                int num = Integer.parseInt(current[1]);
                switch (current[2]) {
                    case "red":
                        if (num > currentRgb[0]) {
                            currentRgb[0] = num;
                        }
                        break;
                    case "green":
                        if (num > currentRgb[1]) {
                            currentRgb[1] = Integer.parseInt(current[1]);
                        }
                        break;
                    case "blue":
                        if (num > currentRgb[2]) {
                            currentRgb[2] = Integer.parseInt(current[1]);   
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        
        return currentRgb[0] * currentRgb[1] * currentRgb[2];
    }


    
    public static void main(String[] args) {
        String path = "test.txt";
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