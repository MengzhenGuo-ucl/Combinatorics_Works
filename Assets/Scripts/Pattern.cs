using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

/// <summary>
/// PatternType can be refered to by name. These can become your block names to make your code more readible. This enum can also be casted to it's assigned integer values. Only define used block types.
/// </summary>
public enum PatternType { PatternA = 0, PatternB = 1 }

/// <summary>
/// The pattern manager is a singleton class. This means there is only one instance of the PatternManager class in the entire project and it can be refered to anywhere withing the project
/// </summary>
public class PatternManager
{
    /// <summary>
    /// Singleton object of the PatternManager class. Refer to this to access the date inside the object.
    /// </summary>
    public static PatternManager Instance { get; } = new PatternManager();


    private static List<Pattern> _patterns;

    /// <summary>
    /// returns a read only list of the patterns defined in the project
    /// </summary>
    public static ICollection<Pattern> Patterns => new ReadOnlyCollection<Pattern>(_patterns);

    /// <summary>
    /// private constructor. All initial patterns will be defined in here
    /// </summary>
    private PatternManager()
    {
        _patterns = new List<Pattern>();

        List<Voxel> patternA = new List<Voxel>();
        patternA.Add(new Voxel(new Vector3Int(0, 0, 0), new List<Vector3Int>(){
        new Vector3Int(-1,0,0),//-X
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        },true));
        patternA.Add(new Voxel(new Vector3Int(1, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        
        }, true));
        patternA.Add(new Voxel(new Vector3Int(2, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternA.Add(new Voxel(new Vector3Int(3, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternA.Add(new Voxel(new Vector3Int(4, 0, 0), new List<Vector3Int>(){
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternA.Add(new Voxel(new Vector3Int(5, 0, 0), new List<Vector3Int>(){
        new Vector3Int(1,0,0),//X
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));

        AddPattern(patternA, PatternType.PatternA);

        //Pattern B
        List<Voxel> patternB = new List<Voxel>();
        patternB.Add(new Voxel(new Vector3Int(0, 0, 0), new List<Vector3Int>(){
        new Vector3Int(-1,0,0),//-X
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternB.Add(new Voxel(new Vector3Int(1, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        
        }, true));
        patternB.Add(new Voxel(new Vector3Int(2, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternB.Add(new Voxel(new Vector3Int(3, 0, 0), new List<Vector3Int>() {
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternB.Add(new Voxel(new Vector3Int(4, 0, 0), new List<Vector3Int>(){
        new Vector3Int(0,-1,0),//-Y
        new Vector3Int(0,1,0),//Y
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));
        patternB.Add(new Voxel(new Vector3Int(5, 0, 0), new List<Vector3Int>(){
        new Vector3Int(1,0,0),//X
        new Vector3Int(0,0,1),//Z
        new Vector3Int(0,0,-1),//-Z
        }, true));

        AddPattern(patternB, PatternType.PatternB);
    }
    /// <summary>
    /// Use this method rather than adding directly to the _patterns field. This method will check if the pattern is valid and can be added to the list. Invalid input will be refused.
    /// </summary>
    /// <param name="voxels">List of indices that define the patter. The indices should always relate to Vector3In(0,0,0) as anchor point</param>
    /// <param name="type">The PatternType of this pattern to add. Each type can only exist once</param>
    /// <returns></returns>
    public bool AddPattern(List<Voxel> voxels, PatternType type)
    {

        //only add valid patterns
        if (voxels == null) return false;
        if (voxels[0].Index != Vector3Int.zero) return false;
        if (_patterns.Count(p => p.Type == type) > 0) return false;
        _patterns.Add(new Pattern(new List<Voxel>(voxels), type));
        return true;
    }

    /// <summary>
    /// Return the pattern linked to its type
    /// </summary>
    /// <param name="type">The type to look for</param>
    /// <returns>The pattern linked to the type. Will return null if the type is never defined</returns>
    public static Pattern GetPatternByType(PatternType type) => Patterns.First(p => p.Type == type);
}
/// <summary>
/// The pattern that defines a block. Object of this class should only be made in the PatternManager
/// </summary>
public class Pattern
{
    /// <summary>
    /// The patterns are saved as ReadOnlyCollections rather than list so that once defined, the pattern can never be changed
    /// </summary>
    public ReadOnlyCollection<Voxel> Voxels { get; }
    public PatternType Type { get; }

    /// <summary>
    /// Pattern constructor. The indices will be stored in a ReadOnlyCollection
    /// </summary>
    ///<param name = "voxels" > List of indices that define the patter.The indices should always relate to Vector3In(0,0,0) as anchor point</param>
    /// <param name="type">The PatternType of this pattern to add. Each type can only exist once</param>
    public Pattern(List<Voxel> voxels, PatternType type)
    {
        Voxels = new ReadOnlyCollection<Voxel>(voxels);
        Type = type;
    }
}

