//*****************************************************************************
//** 2327. Number of People Aware of a Secret                       leetcode **
//*****************************************************************************
//** On day one a secret’s born,                                             **
//** It spreads through whispers, night to morn.                             **
//** But memory fades, the tale grows thin,                                  **
//** Who still remembers when days grow dim?                                 **
//*****************************************************************************

#define MOD 1000000007

int peopleAwareOfSecret(int n, int delay, int forget)
{
    int m = (n << 1) + 10;
    long long *d = (long long*)calloc(m, sizeof(long long));
    long long *cnt = (long long*)calloc(m, sizeof(long long));

    cnt[1] = 1;
    for (int i = 1; i <= n; i++)
    {
        if (cnt[i])
        {
            d[i] = (d[i] + cnt[i]) % MOD;
            d[i + forget] = (d[i + forget] - cnt[i] + MOD) % MOD;

            for (int nxt = i + delay; nxt < i + forget; nxt++)
            {
                cnt[nxt] = (cnt[nxt] + cnt[i]) % MOD;
            }
        }
    }

    long long ans = 0;
    for (int i = 0; i <= n; i++)
    {
        ans = (ans + d[i]) % MOD;
    }

    free(d);
    free(cnt);

    return (int)ans;
}