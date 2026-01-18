a=1
b=2
sum_even=0

while b<4000000:
    if b%2==0:
        sum_even+=b
    a,b=b,a+b
print(sum_even)

def is_squarefree(num):
    factor = 2
    while factor * factor <= num:
        if num % (factor * factor) == 0:
            return False
        while num % factor == 0:
            num //= factor
        factor += 1
    return num > 1 or num == 1


def C(n):
    count = 0
    for x in range(1, n + 1):
        num = x * x + 1
        if is_squarefree(num):
            count += 1
    return count


print( C(123567101113) )
