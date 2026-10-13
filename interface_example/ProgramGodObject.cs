class MajnKraftGodObject
{
    public class Entity
    {
        public float PosX;
        public float PosY;
        public float PosZ;
        public int Health = 20;

        public override string ToString() => $"health: {Health}";

        public virtual void ApplyHealingEffect() { }

        public virtual void Trade() => throw new NotSupportedException($"{GetType().Name} cannot trade emeralds. It has no merchant license.");
        public virtual void OpenInventory() => Console.WriteLine($"{GetType().Name}: Inventory opened [27 slots].");
        public virtual void Mount() => Console.WriteLine($"{GetType().Name}: Player mounted.");
        public virtual void Dismount() => Console.WriteLine($"{GetType().Name}: Player dismounted.");
        public virtual void Ignite() => Console.WriteLine($"{GetType().Name}: Set on fire for 5 seconds.");
        public virtual void Extinguish() => Console.WriteLine($"{GetType().Name}: Fire extinguished.");
        public virtual void Milk() => throw new NotSupportedException($"{GetType().Name} cannot be milked with an iron bucket!");
        public virtual void Shear() => throw new NotSupportedException($"{GetType().Name} does not produce shearable wool!");
        public virtual void LayEgg() => throw new NotSupportedException($"{GetType().Name} does not lay eggs with a 'pop' sound!");
        public virtual void Explode() => Console.WriteLine($"{GetType().Name}: Hssss... BOOM! Destroyed surrounding blocks.");
        public virtual void Barter() => throw new NotSupportedException($"{GetType().Name} does not accept gold ingots for gravel.");
        public virtual void Teleport() => Console.WriteLine($"{GetType().Name}: *Vwoop* Teleported 16 blocks away.");
        public virtual void Breed() => throw new NotSupportedException($"{GetType().Name} cannot breed. Hearts do not appear.");
        public virtual void Tame() => throw new NotSupportedException($"{GetType().Name} cannot be tamed with bones or raw cod.");
        public virtual void Feed() => Console.WriteLine($"{GetType().Name}: Fed food. Crunch crunch crunch.");
        public virtual void SleepInBed() => throw new NotSupportedException($"{GetType().Name} cannot sleep in a red bed.");
        public virtual void EquipArmor() => Console.WriteLine($"{GetType().Name}: Equipped diamond armor.");
        public virtual void DropLoot() => Console.WriteLine($"{GetType().Name}: Dropped 2x sticks and 1x rotten flesh.");
        public virtual void Despawn() => Console.WriteLine($"{GetType().Name}: Vanished into thin air because player is 128 blocks away.");
        public virtual void MakeAggressiveSound() => Console.WriteLine($"{GetType().Name}: *ANGRY MOB SOUND*");
        public virtual void DefendVillage() => throw new NotSupportedException($"{GetType().Name} does not care about villagers.");
        public virtual void CastSpell() => throw new NotSupportedException($"{GetType().Name} cannot summon floor fangs or vexes.");
        public virtual void ShootArrow() => throw new NotSupportedException($"{GetType().Name} does not possess a bow.");
        public virtual void CatchFish() => throw new NotSupportedException($"{GetType().Name} is not holding a fishing rod.");
        public virtual void Sit() => throw new NotSupportedException($"{GetType().Name} cannot sit on command.");
        public virtual void RingBell() => Console.WriteLine($"{GetType().Name}: DING DONG! Village raid warning!");
        public virtual void StealBlock() => throw new NotSupportedException($"{GetType().Name} does not pick up dirt blocks and stare blankly.");
        public virtual void PoisonTarget() => throw new NotSupportedException($"{GetType().Name} does not have venomous fangs.");
        public virtual void ClimbLadder() => Console.WriteLine($"{GetType().Name}: Climbing ladder clack-clack-clack.");
        public virtual void AttachLead() => Console.WriteLine($"{GetType().Name}: Tied to an oak fence post with a lead.");
        public virtual void DanceToJukebox() => Console.WriteLine($"{GetType().Name}: Vibing enthusiastically to Pigstep.");
        public virtual void SplashPotion() => Console.WriteLine($"{GetType().Name}: Threw Splash Potion of Harming II.");
        public virtual void Fly() => throw new NotSupportedException($"{GetType().Name} does not have wings to flap.");
        public virtual void FreezeInPowderSnow() => Console.WriteLine($"{GetType().Name}: Shivering with frosty blue vignette on screen.");
        public virtual void EatGrass() => throw new NotSupportedException($"{GetType().Name} does not consume grass blocks.");
        public virtual void SneezeSlimeball() => throw new NotSupportedException($"{GetType().Name} is not a baby panda with allergies.");
        public virtual void SpitLlamaSpit() => throw new NotSupportedException($"{GetType().Name} cannot spit at wolves.");
        public virtual void StrikeByLightning() => Console.WriteLine($"{GetType().Name}: Struck by lightning! Blue electric sparks crackle.");
        public virtual void WearPumpkin() => Console.WriteLine($"{GetType().Name}: Carved pumpkin placed on head.");
        public virtual void InflatePufferfish() => throw new NotSupportedException($"{GetType().Name} cannot puff up into a spiky poison balloon.");
        public virtual void GiveBadOmen() => throw new NotSupportedException($"{GetType().Name} is not an ominous raid captain.");
        public virtual void HowlAtMoon() => throw new NotSupportedException($"{GetType().Name} does not howl at the full moon.");
        public virtual void PanicAndRun() => Console.WriteLine($"{GetType().Name}: Flailing arms and running in random circles!");
        public virtual void TransformToZombie() => Console.WriteLine($"{GetType().Name}: Infected and transformed into a zombie variant!");
        public virtual void PollinateFlower() => throw new NotSupportedException($"{GetType().Name} does not collect pollen for a beehive.");
        public virtual void StareEndermanIntently() => Console.WriteLine($"{GetType().Name}: Looked directly into Enderman eyes. Big mistake.");
        public virtual void SwimInLava() => Console.WriteLine($"{GetType().Name}: Swimming through molten lava.");
        public virtual void BreakDoor() => Console.WriteLine($"{GetType().Name}: Bang! Bang! Bang! Wooden door shattered!");
        public virtual void BuildSnowGolem() => Console.WriteLine($"{GetType().Name}: Placed two snow blocks and a pumpkin.");
        public virtual void SleepUpsideDown() => throw new NotSupportedException($"{GetType().Name} cannot hang from the ceiling like a bat.");
        public virtual void EvaporateInSunlight() => Console.WriteLine($"{GetType().Name}: Sizzle! Catching fire under direct sunlight.");
        public virtual void DetonateTNT() => Console.WriteLine($"{GetType().Name}: Lit TNT fuse: 4... 3... 2... 1... BOOM!");
    }

    public class Boat : Entity
    {
        public bool HasPlayer;

        public override void ApplyHealingEffect()
        {
            Console.WriteLine("Boat: Splashing a healing potion on oak wood... Congratulations, you now have wet wood.");
        }

        public override void Mount() => Console.WriteLine("Boat: Player hopped into the boat seat.");
        public override void Dismount() => Console.WriteLine("Boat: Player hopped out of the boat.");
        public override void OpenInventory() => Console.WriteLine("Boat: Opened chest boat inventory.");
        public override void Milk() => throw new InvalidOperationException("Boat: You tried to milk a wooden boat with an iron bucket. Please re-evaluate your life choices.");
        public virtual void RowPaddle() => Console.WriteLine("Boat: Splash splash rowing.");

        public override string ToString() => $"Boat: {base.ToString()}";
    }

    public class Skeleton : Entity
    {
        public override void ApplyHealingEffect() => Health += 10;

        public override void ShootArrow() => Console.WriteLine("Skeleton: Twang! Fired an arrow with pinpoint accuracy.");
        public override void EvaporateInSunlight() => Console.WriteLine("Skeleton: Sizzle! Burning in daylight! Seeking shade under a tree!");
        public override void Mount() => Console.WriteLine("Skeleton: Mounted a spider! Spider Jockey formed!");
        public override void Milk() => throw new NotSupportedException("Skeleton: There is no milk here, only dry calcium.");
        public override void LayEgg() => throw new NotSupportedException("Skeleton: Skeletons do not hatch from eggs.");
        public override void Trade() => throw new NotSupportedException("Skeleton: Skeletons do not trade emeralds. They only want your bones.");

        public override string ToString() => $"Skeleton: {base.ToString()}";
    }

    public class WitherSkeleton : Entity
    {
        public override void ApplyHealingEffect() => Health -= 10; // Healing harms Wither Skeletons!

        public override void Ignite() => Console.WriteLine("WitherSkeleton: Completely immune to fire! Standing in flames unbothered.");
        public override void StrikeByLightning() => Console.WriteLine("WitherSkeleton: Struck by lightning! Now even more terrifying.");
        public override void Trade() => throw new NotSupportedException("WitherSkeleton: Attempted to trade. Result: Wither effect applied, you died.");
        public override void Milk() => throw new NotSupportedException("WitherSkeleton: Drinking wither milk would delete your game save.");

        public override string ToString() => $"WitherSkeleton: {base.ToString()}";
    }

    public static void Main(string[] args)
    {
        List<Entity> entities = [new Boat(), new Skeleton(), new WitherSkeleton()];

        foreach (Entity entity in entities)
        {
            entity.ApplyHealingEffect();
        }
        Console.WriteLine(string.Join("\n", entities.Select(x => x.ToString())));
    }
}
