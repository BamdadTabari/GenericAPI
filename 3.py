import sys
from collections import deque

def simulate_traffic(n, m, horizontal_intersections, vertical_intersections):
    """
    Simulate traffic flow and return the maximum time taken by any taxi to reach its destination.
    
    Args:
    n (int): Number of horizontal streets
    m (int): Number of vertical streets
    horizontal_intersections (list): List of tuples representing horizontal intersections
    vertical_intersections (list): List of tuples representing vertical intersections
    
    Returns:
    int: Maximum time taken by any taxi to reach its destination
    """
    max_time = 0
    current_time = 0

    # Initialize queues for taxis starting at each intersection
    horizontal_queues = [deque() for _ in range(n)]
    vertical_queues = [deque() for _ in range(m)]

    # Populate initial queues
    for i, (_, capacity) in enumerate(horizontal_intersections):
        horizontal_queues[i].extend(range(i, n))

    for i, (_, capacity) in enumerate(vertical_intersections):
        vertical_queues[i].extend(range(i, m))

    while True:
        # Update current time
        current_time += 1
        max_time = max(max_time, current_time)

        # Process horizontal intersections
        for i in range(n):
            if horizontal_queues[i]:
                taxi_id = horizontal_queues[i].popleft()
                if taxi_id < n - 1:
                    horizontal_queues[taxi_id + 1].append(taxi_id)
        
        # Process vertical intersections
        for i in range(m):
            if vertical_queues[i]:
                taxi_id = vertical_queues[i].popleft()
                if taxi_id < m - 1:
                    vertical_queues[taxi_id + 1].append(taxi_id)

        # Check if all taxis have reached their destinations
        if not any(queue for queue in horizontal_queues + vertical_queues):
            break

    return max_time

def main():
    input_data = sys.stdin.read().split()
    
    n, m = map(int, input_data[:2])
    input_data = input_data[2:]

    horizontal_intersections = []
    for _ in range(n):
        _, capacity = map(int, input_data[:2])
        horizontal_intersections.append((_, capacity))
        input_data = input_data[2:]

    vertical_intersections = []
    for _ in range(m):
        _, capacity = map(int, input_data[:2])
        vertical_intersections.append((_, capacity))
        input_data = input_data[2:]

    result = simulate_traffic(n, m, horizontal_intersections, vertical_intersections)
    print(result)

if __name__ == "__main__":
    main()
