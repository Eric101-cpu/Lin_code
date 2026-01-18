a=1
sum=0
while a<1000:
    if a%3==0 or a%5==0:
        sum+=a
    a+=1
print(sum)