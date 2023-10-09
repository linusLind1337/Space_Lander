Assignment_SpaceLander 2D

# OverView
So I chose to make a Space 2D game, where my idea is that you are a spacecraft. Your main goal is to get from start to finish and try to evade those dangerous enemies either by dodging or by using the shields that are scattered all over the map, there are also bunch of landing pads that give you a full boost, now keep in mind the game is supposed to be hard so you won't know where then next landing pad is until you find it.....and no there aren't any checkpoints.....GOOD LUCK.

The game has 3 levels of difficulties:
* Level 1 is easy,
* Level 2 is medium
* Level 3 is hard close to impossible

# Why I chose this Game

So the reason I chose this game is that I find these type of games fun, challening and because the teach love his "space shooter" typ of games. I am quite happy that i chose this game because i've learned quite a bit even tho i've programming for a little while, but hey thats the reason I joined FG, to learn and have fun, and that's what i am doing. now I must say

# issues that occurred during the development
So during the making of the game, I stumbled across multiple issues, the issues could be all from the computer not working properly, unity being unity, and coding issues, now these are just a few of the issues, we get more detailed later.

The main issue I had was that my home computer wasn't working as it was supposed to, I spent multiple hours trying to make it work and that took away valuable time from me, time that I could have spent more on the game.

The other issues I faced were of course in Unity, we all know how Unity can be sometimes, so the assignment I got, it wants me to use Unity's new input system the problem was that I couldn't install it on my home pc for some reason, still do not know the issue, but I could/can install it perfectly fine on my computer at school, so I had to stick to the older input system(sad), but I got to work because the time is valuable, now early in development I didn't face a whole lot of problems it all went as how I wanted it to go, it was more in the late development where I faced the issue of my rocket not wanting to boost towards my mouse on first mouseclick I fixed that by using: 

```
if (Input.GetMouseButtonDown(0) && !boostEnabled)
        {
            EnableBoost();
            psFire.Play();
            
        }
```
Where I added the !boostEnabled when mouse0 is pressed, I remade my Boosting() by adding a vector3 direction and using rigidbody2d.addforce, before I belivde i used moveTowards and it worked but not perfect.
```
public void Boosting()
    {
        // A vector pointing from current pos to target pos;
        Vector3 Direction = (target - transform.position);
        rb2d.AddForce(Direction * boostSpeed);
        _Boost.canPlayerBoost = false;

    }
```

I also faced quite some problems with my time and best time, never been so frustrated in my life, took me 2 days to get it to work, now i haven't used PlayerPref's to much but i've now learned how to use them correcly. So the issue I had were that i wanted to have a timer that keeps running from start of the level 1 and stop when u get to level 3 and reaches the finish but it just kept on reseting on each level change, so i got another idea, where I just start the timer on each scene and the user has their best time on each scene, and it looked and felt much better then what i originaly wanted to have.

So how I got my PlayerPref's to work were that I found a "tutorial" or guide on how to use playerPref's and it teached very good, easy to read and understand. 

# Plans for the game

So I had quite some idea i wanted to add to my game, but due to the issues and time it took to fix them and the I didnt have enough time to work on assets, design etc to make the game feel more "alive", tho i will still work on this game because it's a good game to have and to look back and reflect/learn from. 
