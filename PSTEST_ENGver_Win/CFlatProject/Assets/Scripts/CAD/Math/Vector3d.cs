using System;
using Chiyoda;

namespace UnityEngine
{
  public struct Vector3d
  {
    public const double kEpsilon = 1e-5 ;

    public double x ;
    public double y ;
    public double z ;

    public double this[ int index ]
    {
      get
      {
        switch ( index ) {
          case 0 :
            return this.x ;
          case 1 :
            return this.y ;
          case 2 :
            return this.z ;
          default :
            throw new IndexOutOfRangeException( "Invalid index!" ) ;
        }
      }
      set
      {
        switch ( index ) {
          case 0 :
            this.x = value ;
            break ;
          case 1 :
            this.y = value ;
            break ;
          case 2 :
            this.z = value ;
            break ;
          default :
            throw new IndexOutOfRangeException( "Invalid Vector3d index!" ) ;
        }
      }
    }

    public Vector3d normalized
    {
      get { return Vector3d.Normalize( this ) ; }
    }

    public double magnitude
    {
      get { return Math.Sqrt( this.x * this.x + this.y * this.y + this.z * this.z ) ; }
    }

    public double sqrMagnitude
    {
      get { return this.x * this.x + this.y * this.y + this.z * this.z ; }
    }

    public static Vector3d zero
    {
      get { return new Vector3d( 0d, 0d, 0d ) ; }
    }

    public static Vector3d one
    {
      get { return new Vector3d( 1d, 1d, 1d ) ; }
    }

    /// <summary>( 0, 0, +1 )</summary>
    public static Vector3d forward
    {
      get { return new Vector3d( 0d, 0d, 1d ) ; }
    }

    /// <summary>( 0, 0, -1 )</summary>
    public static Vector3d back
    {
      get { return new Vector3d( 0d, 0d, -1d ) ; }
    }

    /// <summary>( 0, +1, 0 )</summary>
    public static Vector3d up
    {
      get { return new Vector3d( 0d, 1d, 0d ) ; }
    }

    /// <summary>( 0, -1, 0 )</summary>
    public static Vector3d down
    {
      get { return new Vector3d( 0d, -1d, 0d ) ; }
    }

    /// <summary>( -1, 0, 0 )</summary>
    public static Vector3d left
    {
      get { return new Vector3d( -1d, 0d, 0d ) ; }
    }

    /// <summary>( +1, 0, 0 )</summary>
    public static Vector3d right
    {
      get { return new Vector3d( 1d, 0d, 0d ) ; }
    }

    public Vector3d( double x, double y, double z )
    {
      this.x = x ;
      this.y = y ;
      this.z = z ;
    }

    public Vector3d( float x, float y, float z )
    {
      this.x = (double) x ;
      this.y = (double) y ;
      this.z = (double) z ;
    }

    public Vector3d( Vector3 v3 )
    {
      this.x = (double) v3.x ;
      this.y = (double) v3.y ;
      this.z = (double) v3.z ;
    }

    public Vector3d( double x, double y )
    {
      this.x = x ;
      this.y = y ;
      this.z = 0d ;
    }

    public static Vector3d operator +( in Vector3d a, in Vector3d b )
    {
      return new Vector3d( a.x + b.x, a.y + b.y, a.z + b.z ) ;
    }

    public static Vector3d operator -( in Vector3d a, in Vector3d b )
    {
      return new Vector3d( a.x - b.x, a.y - b.y, a.z - b.z ) ;
    }

    public static Vector3d operator -( in Vector3d a )
    {
      return new Vector3d( -a.x, -a.y, -a.z ) ;
    }

    public static Vector3d operator *( in Vector3d a, double d )
    {
      return new Vector3d( a.x * d, a.y * d, a.z * d ) ;
    }

    public static Vector3d operator *( double d, in Vector3d a )
    {
      return new Vector3d( a.x * d, a.y * d, a.z * d ) ;
    }

    public static Vector3d operator /( in Vector3d a, double d )
    {
      return new Vector3d( a.x / d, a.y / d, a.z / d ) ;
    }

    public static bool operator ==( in Vector3d lhs, in Vector3d rhs )
    {
      return ( lhs.x == rhs.x ) && ( lhs.y == rhs.y ) && ( lhs.z == rhs.z ) ;
    }

    public static bool operator !=( in Vector3d lhs, in Vector3d rhs )
    {
      return ! ( lhs == rhs ) ;
    }

    public static implicit operator Vector3d( in Vector3 vector3 )
    {
      return new Vector3d( vector3 ) ;
    }

    public static explicit operator Vector3( in Vector3d vector3d )
    {
      return new Vector3( (float) vector3d.x, (float) vector3d.y, (float) vector3d.z ) ;
    }

    public static Vector3d Lerp( in Vector3d from, in Vector3d to, double t )
    {
      if ( t < 0 ) t = 0 ;
      else if ( 1 < t ) t = 1 ;

      return new Vector3d( from.x + ( to.x - from.x ) * t, from.y + ( to.y - from.y ) * t, from.z + ( to.z - from.z ) * t ) ;
    }

    //public static Vector3d Slerp( in Vector3d from, in Vector3d to, double t )
    //{
    //  if ( t < 0 ) t = 0;
    //  else if ( 1 < t ) t = 1;

    //  double dot = Vector3d.Dot( from, to );
    //  double crossVec = Vector3d.Cross( from, to );
    //  double cross = crossVec.magnitude;
    //  return ToDegree( Math.Atan2( cross, dot ) );
    //  Vector3 v3 = Vector3.Slerp( (Vector3)from, (Vector3)to, (float)t );
    //  return new Vector3d( v3 );
    //}

    //public static void OrthoNormalize( ref Vector3d normal, ref Vector3d tangent )
    //{
    //  Vector3 v3normal = new Vector3();
    //  Vector3 v3tangent = new Vector3();
    //  v3normal = (Vector3)normal;
    //  v3tangent = (Vector3)tangent;
    //  Vector3.OrthoNormalize( ref v3normal, ref v3tangent );
    //  normal = new Vector3d( v3normal );
    //  tangent = new Vector3d( v3tangent );
    //}

    //public static void OrthoNormalize( ref Vector3d normal, ref Vector3d tangent, ref Vector3d binormal )
    //{
    //  Vector3 v3normal = new Vector3();
    //  Vector3 v3tangent = new Vector3();
    //  Vector3 v3binormal = new Vector3();
    //  v3normal = (Vector3)normal;
    //  v3tangent = (Vector3)tangent;
    //  v3binormal = (Vector3)binormal;
    //  Vector3.OrthoNormalize( ref v3normal, ref v3tangent, ref v3binormal );
    //  normal = new Vector3d( v3normal );
    //  tangent = new Vector3d( v3tangent );
    //  binormal = new Vector3d( v3binormal );
    //}

    public static Vector3d MoveTowards( in Vector3d current, in Vector3d target, double maxDistanceDelta )
    {
      Vector3d vector3 = target - current ;
      double magnitude = vector3.magnitude ;
      if ( magnitude <= maxDistanceDelta || magnitude == 0.0d )
        return target ;
      else
        return current + vector3 / magnitude * maxDistanceDelta ;
    }

    //public static Vector3d RotateTowards( Vector3d current, Vector3d target, double maxRadiansDelta, double maxMagnitudeDelta )
    //{
    //  Vector3 v3 = Vector3.RotateTowards( (Vector3)current, (Vector3)target, (float)maxRadiansDelta, (float)maxMagnitudeDelta );
    //  return new Vector3d( v3 );
    //}

    public void Set( double x, double y, double z )
    {
      this.x = x ;
      this.y = y ;
      this.z = z ;
    }

    public static Vector3d Scale( in Vector3d a, in Vector3d b )
    {
      return new Vector3d( a.x * b.x, a.y * b.y, a.z * b.z ) ;
    }

    public void Scale( in Vector3d scale )
    {
      this.x *= scale.x ;
      this.y *= scale.y ;
      this.z *= scale.z ;
    }

    public static Vector3d Cross( in Vector3d lhs, in Vector3d rhs )
    {
      return new Vector3d( lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x ) ;
    }

    public override int GetHashCode()
    {
      return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ;
    }

    public override bool Equals( object other )
    {
      if ( other is Vector3d vector3d ) {
        if ( this.x.Equals( vector3d.x ) && this.y.Equals( vector3d.y ) )
          return this.z.Equals( vector3d.z ) ;
        else
          return false ;
      }
      else {
        return false ;
      }
    }

    public static Vector3d Reflect( in Vector3d inDirection, in Vector3d inNormal )
    {
      return -2d * Vector3d.Dot( inNormal, inDirection ) * inNormal + inDirection ;
    }

    public static Vector3d Normalize( in Vector3d value )
    {
      double num = Vector3d.Magnitude( value ) ;
      if ( num >= kEpsilon )
        return value / num ;
      else
        return Vector3d.zero ;
    }

    public void Normalize()
    {
      double num = Vector3d.Magnitude( this ) ;
      if ( num >= kEpsilon )
        this = this / num ;
      else
        this = Vector3d.zero ;
    }

    public override string ToString()
    {
      return string.Format( "({0}, {1}, {2})", this.x, this.y, this.z ) ;
    }

    public static double Dot( in Vector3d lhs, in Vector3d rhs )
    {
      return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z ;
    }

    public static Vector3d Project( in Vector3d vector, in Vector3d onNormal )
    {
      double num = Vector3d.Dot( onNormal, onNormal ) ;
      if ( num >= kEpsilon )
        return Vector3d.zero ;
      else
        return onNormal * Vector3d.Dot( vector, onNormal ) / num ;
    }

    public static Vector3d Exclude( in Vector3d excludeThis, in Vector3d fromThat )
    {
      return fromThat - Vector3d.Project( fromThat, excludeThis ) ;
    }

    public static double Angle( in Vector3d from, in Vector3d to )
    {
      double dot = Vector3d.Dot( from, to ) ;
      double cross = Vector3d.Cross( from, to ).magnitude ;
      return Math.Atan2( cross, dot ).Rad2Deg() ;
    }

    public static double Distance( in Vector3d a, in Vector3d b )
    {
      var x = a.x - b.x ;
      var y = a.y - b.y ;
      var z = a.z - b.z ;
      return Math.Sqrt( x * x + y * y + z * z ) ;
    }

    public static Vector3d ClampMagnitude( in Vector3d vector, double maxLength )
    {
      if ( vector.sqrMagnitude > maxLength * maxLength )
        return vector.normalized * maxLength ;
      else
        return vector ;
    }

    public static double Magnitude( in Vector3d a )
    {
      return Math.Sqrt( a.x * a.x + a.y * a.y + a.z * a.z ) ;
    }

    public static double SqrMagnitude( in Vector3d a )
    {
      return a.x * a.x + a.y * a.y + a.z * a.z ;
    }

    public static Vector3d Min( in Vector3d lhs, in Vector3d rhs )
    {
      return new Vector3d( Math.Min( lhs.x, rhs.x ), Math.Min( lhs.y, rhs.y ), Math.Min( lhs.z, rhs.z ) ) ;
    }

    public static Vector3d Max( in Vector3d lhs, in Vector3d rhs )
    {
      return new Vector3d( Math.Max( lhs.x, rhs.x ), Math.Max( lhs.y, rhs.y ), Math.Max( lhs.z, rhs.z ) ) ;
    }
  }
}