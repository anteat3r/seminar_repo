class MajnKraft
{
    class Entity
    {
        public float PosX;
        public float PosY;
        public float PosZ;
        public int Health = 20;

        public override string ToString() => $"health: {Health}";
    }

    class Boat : Entity
    {
        public bool HasPlayer;
        public override string ToString() => $"Boat: {base.ToString()}";
    }

    interface HealingEffectApplicant
    {
        void ApplyHealingEffect();
    }

    class Skeleton : Entity, HealingEffectApplicant
    {
        public void ApplyHealingEffect() => Health += 10;
        public override string ToString() => $"Skeleton: {base.ToString()}";
    }

    class WitherSkeleton : Entity, HealingEffectApplicant
    {
        public void ApplyHealingEffect() => Health -= 10;
        public override string ToString() => $"WitherSkeleton: {base.ToString()}";
    }

    public static void Main(string[] Args)
    {
        List<Entity> entities = [new Boat(), new Skeleton(), new WitherSkeleton()];
        foreach (Entity entity in entities)
            if (entity is HealingEffectApplicant applicant)
                applicant.ApplyHealingEffect();
        Console.WriteLine(String.Join("\n", entities.Select(x => x.ToString())));
    }
}
