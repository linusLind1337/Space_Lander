
 # **Assignment_SpaceLander 2D**

- [Introcution](#Intro)
- [Reasons](#Why-This-Game)
- [Issues](#Development-Issues)
- [Future Plans](#Plans-for-the-game)
- [Credits](#Credits)

# Intro
So I chose to make a Space 2D game, where my idea is that you are a spacecraft. Your main goal is to get from start to finish and try to evade those dangerous enemies either by dodging or by using the shields that are scattered all over the map, there are also a bunch of landing pads that give you a full boost, now keep in mind the game is supposed to be hard so you won't know where then next landing pad is until you find it.....and no there aren't any checkpoints.....GOOD LUCK.

The game has 3 levels of difficulties:
* Level 1 is easy,
* Level 2 is medium
* Level 3 is hard close to impossible


# Why This Game

So the reason I chose this game is that I find these types of games fun to play, and challenging, and because the teacher loves his "space shooter" type of games. I am quite happy that I chose this game because I've learned quite a bit even tho I've been programming for a while, but still ain't the best, but hey that's the reason I joined FG, to learn and have fun, and that's what I am doing. 

now I must say it was a bit more challenging than I thought it was going to be, though I've never really made this type of game before

# Development Issues
So during the making of the game, I stumbled across multiple issues, the issues could be all from the computer not working properly, unity being unity, and coding issues, now these are just a few of the issues, we get more detailed later.

The main issue I had was that my home computer wasn't working as it was supposed to, I spent multiple hours trying to make it work and that took away valuable time from me, time that I could have spent more on the game.

The other issues I faced were of course in Unity, we all know how Unity can be sometimes, so the assignment I got, wanted me to use Unity's new input system the problem was that I couldn't install it on my home pc for some reason, still do not know the issue, but I could/can install it perfectly fine on my computer at school, so I had to stick to the older input system(sad), but I got to work because the time is valuable, now early in development I didn't face a whole lot of problems it all went as how I wanted it to go, it was more in the late development where I faced the issue of my rocket not wanting to boost towards my mouse on first mouseclick I fixed that by using: 

```
if (Input.GetMouseButtonDown(0) && !boostEnabled)
        {
            EnableBoost();
            psFire.Play();
            
        }
```
Where I added the !boostEnabled when mouse0 is pressed, I remade my Boosting() by adding a vector3 direction and using rigidbody2d.addforce, I believe I used moveTowards and it worked but not perfectly.
```
public void Boosting()
    {
        // A vector pointing from current pos to target pos;
        Vector3 Direction = (target - transform.position);
        rb2d.AddForce(Direction * boostSpeed);
        _Boost.canPlayerBoost = false;

    }
```

I also faced quite some problems with my time and best time, never been so frustrated in my life, took me 2 days to get it to work, now I haven't used PlayerPref too much but I've now learned how to use it properly. So the issue I had was that I wanted to have a timer that keeps running from the start of level 1 and stops when u get to level 3 and reaches the finish but it just kept on resetting on each level change, so I got another idea, where I start the timer on each scene and the user has their best time on each scene, and it looked and felt much better then what I originally wanted to have.

So how I got my PlayerPrefs to work was that I found a "tutorial" or guide on how to use playerPref and it was very good, easy to read and understand. 

# Plans for the game

So I had quite some ideas I wanted to add to my game, but due to the issues and time it took to fix them I didn't have enough time to work on assets, design, etc to make the game feel more "alive", tho I will still work on this game because it's a good game to have and to look back and reflect/learn from. 

# Credits

* https://docs.unity3d.com/ScriptReference/ is the main site I've used during this project.
* https://gamedevbeginner.com/how-to-use-player-prefs-in-unity/ how I learned/understood how to use PlayerPrefs better.
* My older brother that helped me with a few things, on how it should be handled, some code parts, and other small things.
* https://www.youtube.com/@Brackeys The man the myth the legend BRACKEYS, used him more to refresh some parts that I've forgotten how to do.

  Now keep in mind I can't remember all the websites but there are a few more, that I've just used to research more on how to do etc, or if any other people had the same problem like me.


