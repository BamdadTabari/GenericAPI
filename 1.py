def display_dynamic_pattern(n, binary_string, patterns):
    """
    Display the binary string as a dynamic pattern according to the given rules.
    
    Args:
    n (int): Length of the binary string
    binary_string (str): Binary string containing characters
    patterns (dict): Dictionary of patterns for each character
    
    Returns:
    str: Multi-line string representation of the dynamic pattern
    """
    lines = [''] * len(next(iter(patterns.values())))
    for char in binary_string:
        for i, pattern_line in enumerate(patterns.get(char, [])):
            lines[i] += pattern_line
    
    return '\n'.join(lines)

def main():
    import sys
    input_data = sys.stdin.read().split()
    
    n = int(input_data[0])
    binary_string = input_data[1]
    
    # Define dynamic patterns
    patterns = {
        '0': ['***', '*.*', '***'],
        '1': ['.*.', '.**', '.*.']
    }
    
    result = display_dynamic_pattern(n, binary_string, patterns)
    print(result)

if __name__ == "__main__":
    main()
