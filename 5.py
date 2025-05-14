import heapq
from collections import defaultdict

def max_cakes(n, t, T, shops):
    """
    Calculate the maximum number of cakes collected and the number of unique shops visited.
    
    Args:
    n (int): Number of shops
    t (int): Time interval between visits
    T (int): Total time limit
    shops (list): List of tuples containing (x, y, a) coordinates and cake amount
    
    Returns:
    tuple: (max_cakes, num_shops_visited, visited_times_and_shops)
    """
    events = []
    for i, (x, y, a) in enumerate(shops):
        dist = x + y  # Distance is approximated as Manhattan distance
        time = dist
        while time <= T:
            heapq.heappush(events, (time, a, i + 1))
            time += t

    total_cakes = 0
    visited = set()
    while events:
        time, cakes, shop_id = heapq.heappop(events)
        if time > T:
            break
        total_cakes += cakes
        visited.add(shop_id)

    return total_cakes, len(visited), list(visited)

def main():
    n, t, T = map(int, input().split())
    shops = [tuple(map(int, input().split())) for _ in range(n)]

    result = max_cakes(n, t, T, shops)
    print(result[0], result[1])
    for time, shop_id in result[2]:
        print(time, shop_id)

if __name__ == "__main__":
    main()
