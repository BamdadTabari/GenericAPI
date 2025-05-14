import sys

def calculate_min_energy(n_g: int, n_q: int, arrangement: str) -> int:
    """
    Calculate the minimum energy needed to group employees based on their arrangement.
    
    Args:
    n_g (int): Number of 'G' employees.
    n_q (int): Number of 'Q' employees.
    arrangement (str): String containing 'G' and 'Q' characters representing employee positions.
    
    Returns:
    int: Minimum energy required to group employees.
    """
    g_indices = [i for i, c in enumerate(arrangement) if c == 'G']
    q_indices = [i for i, c in enumerate(arrangement) if c == 'Q']

    def calculate_prefix_sum(indices):
        """Calculate prefix sum for given indices."""
        prefix_sum = [0] * (len(arrangement) + 1)
        for i, idx in enumerate(indices):
            prefix_sum[i + 1] = prefix_sum[i] + idx
        return prefix_sum

    def calculate_min_energy_for_group(group_indices, group_char):
        """Calculate minimum energy for grouping all employees of a specific type."""
        prefix_sum = calculate_prefix_sum(group_indices)
        
        min_energy = float('inf')
        for i in range(len(arrangement) - len(group_indices) + 1):
            left_cost = prefix_sum[len(group_indices)] - prefix_sum[0] - len(group_indices) * i
            min_energy = min(min_energy, abs(left_cost))
        
        return min_energy

    # Calculate minimum energy for 'G' grouping
    g_min_energy = calculate_min_energy_for_group(g_indices, 'G')

    # Calculate minimum energy for 'Q' grouping
    q_min_energy = calculate_min_energy_for_group(q_indices, 'Q')

    return min(g_min_energy, q_min_energy)

def main():
    """
    Read input data and process test cases.
    
    Returns:
    List[int]: List of minimum energies required for each test case.
    """
    import sys
    input_data = sys.stdin.read().split()

    t = int(input_data[0])
    test_cases = []
    idx = 1

    for _ in range(t):
        n = int(input_data[idx])
        m = int(input_data[idx + 1])
        arrangement = input_data[idx + 2]
        test_cases.append((n, m, arrangement))
        idx += 3

    return [calculate_min_energy(n, m, arrangement) 
            for n, m, arrangement in test_cases]

if __name__ == "__main__":
    results = main()
    sys.stdout.write("\n".join(map(str, results)) + "\n")
