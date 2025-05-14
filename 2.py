import heapq

def golrang_shampoo_schedule(n, shampoos):
    """
    Determines the first available shampoo for each customer based on their arrival time and shampoo reuse interval.

    Args:
        n (int): Number of customers.
        shampoos (list of tuples): Each tuple contains (t, x), where t is the arrival time and x is the reuse interval.

    Returns:
        list: List of indices (1-based) of the shampoo assigned to each customer.
    """
    # Priority queue to track shampoos by their next available time
    available_shampoos = []

    # Result list to store the index of the first available shampoo for each customer
    results = []

    # Iterate over each customer's arrival time and shampoo's reuse interval
    for i, (t, x) in enumerate(shampoos):
        # Remove shampoos that are available before the current time
        while available_shampoos and available_shampoos[0][0] <= t:
            heapq.heappop(available_shampoos)

        # Assign the current shampoo to the customer and update its next available time
        heapq.heappush(available_shampoos, (t + x, i + 1))

        # Record the index of the shampoo assigned
        results.append(available_shampoos[0][1])

    return results

# Input reading
if __name__ == "__main__":
    import sys
    input = sys.stdin.read
    data = input().splitlines()

    n = int(data[0])  # Number of customers
    shampoos = [tuple(map(int, line.split())) for line in data[1:]]

    # Get the output and print results
    output = golrang_shampoo_schedule(n, shampoos)
    sys.stdout.write("\n".join(map(str, output)) + "\n")
