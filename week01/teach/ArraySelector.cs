public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        //first we create an array according to the length of select array
        //This is the new list resulting from the two lists (list1 and list2)
        var result = new int[select.Length];
        //Track the indexes where the selector stayed
        var index1 = 0;
        var index2 = 0;

        // set a loop into select
        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                result[i] = list1[index1++];

            }
            else
            {
                result[i] = list2[index2++];
            }
        }

        return result;
    }
}