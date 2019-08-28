#include <stdio.h>

void putchar_f64(double n)
{
    putchar((int)n);
}

void putchar_i64(long long int n)
{
    putchar((int)n);
}

void consume_i64(long long int n)
{
}

void printlnd(double value)
{
    printf("%f\n", value);
}

void printlni(long long int value)
{
    printf("%I64d\n", value);
}

void println(void)
{
    printf("\n");
}

extern void MAIN(void);

int main(void)
{
    MAIN();
}