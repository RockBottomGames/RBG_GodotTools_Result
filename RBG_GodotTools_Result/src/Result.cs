namespace RBG_GodotTools_Result;

using System;
using Godot;

/// <summary>
/// Holds constants related to RBG_Result class
/// </summary>
public static class RBG_Result_Constants {
  /// <summary>
  ///  The Code that indicates a value that hasn't been evaluated yet.
  /// </summary>
  public const int NOT_EVALUATED_CODE = -1;
  /// <summary>
  /// The Code that indicates a successful result.
  /// </summary>
  public const int SUCCESS_CODE = 0;
  /// <summary>
  ///  The Code that indicates a value that hasn't been evaluated yet.
  /// </summary>
  public const int GENERIC_DEVELOPER_ERROR_CODE = 1;
}

/// <summary>
/// RBG_Result (Immutable) class holds a message, an error code, and keeps track if it is an error,
/// and if it has been evaluated. Empty RBG_Result should be treated as success.
/// </summary>
/// <typeparam name="T">Type for Result's Value.</typeparam>
public class RBG_Result<T> : Resource, IEquatable<RBG_Result<T>> where T : IEquatable<T> {
  /// <summary>
  /// Message to describe the result, ignored in determining if result is an error.
  /// </summary>
  public string Message { get; }

  /// <summary>
  /// Code to help identify specific errors. Zero should be used when there is no error,
  /// and -1 should be used when result has not yet been evaluated.
  /// </summary>
  public int Code { get; }

  /// <summary>
  /// Flag to quickly check if this result is an error.
  /// </summary>
  public bool IsEvaluated { get; }

  /// <summary>
  /// Flag to quickly check if this result is an error.
  /// </summary>
  public bool IsError { get; }

  /// <summary>
  /// The system corrected result value, or null if it could not be corrected.
  /// This can be used to suggest a corrected value to the user/developer.
  /// </summary>
  public T? Value { get; }

  /// <summary>
  /// Constructs a Result object.
  /// </summary>
  /// <param name="value">The system corrected value, or null if it could not be corrected.</param>
  /// <param name="message">Message to describe the result, ignored in determining if result is an error.</param>
  /// <param name="code">
  /// Code to help identify specific errors. Zero should be used when there is no error,
  /// and -1 should be used when result has not yet been evaluated.
  /// </param>
  public RBG_Result(T? value = default, string message = "", int code = RBG_Result_Constants.NOT_EVALUATED_CODE) {
    Message = message;
    Code = code;
    IsEvaluated = code != RBG_Result_Constants.NOT_EVALUATED_CODE;
    IsError = code != RBG_Result_Constants.SUCCESS_CODE && IsEvaluated;
    Value = value;
  }

  /// <summary>
  /// Determines whether the specified object is equal to the other specified object.
  /// </summary>
  /// <param name="obj1">Object for basis of comparison.</param>
  /// <param name="obj2">Object to compare basis to.</param>
  /// <returns>'true' if the specified object is equal to the current object; otherwise, 'false'.</returns>
  public static bool operator ==(RBG_Result<T>? obj1, RBG_Result<T>? obj2) => obj1 is null ? obj2 is null : obj1.Equals(obj2);

  /// <summary>
  /// Determines whether the specified object is not equal to the other specified object.
  /// </summary>
  /// <param name="obj1">Object for basis of comparison.</param>
  /// <param name="obj2">Object to compare basis to.</param>
  /// <returns>'true' if the specified object is not equal to the current object; otherwise, 'false'.</returns>
  public static bool operator !=(RBG_Result<T>? obj1, RBG_Result<T>? obj2) => !(obj1 == obj2);

  private bool ValueEquals(RBG_Result<T> other) => Value is null
    ? other.Value is null
    : Value.Equals(other.Value);

  /// <summary>
  /// Determines whether the specified RBG_Result is equal to the current object.
  /// </summary>
  /// <param name="other">RBG_Result to compare this one to.</param>
  /// <returns>'true' if the specified object is equal to the current object; otherwise, 'false'.</returns>
  public bool Equals(RBG_Result<T>? other) => other is not null
    && (ReferenceEquals(this, other)
    || (GetType() == other.GetType()
      && ValueEquals(other)
      && Message.Equals(other.Message, StringComparison.Ordinal)
      && Code.Equals(other.Code)));

  /// <summary>
  /// Determines whether the specified object is equal to the current object.
  /// </summary>
  /// <param name="obj">Object to compare this one to.</param>
  /// <returns>'true' if the specified object is equal to the current object; otherwise, 'false'.</returns>
  public override bool Equals(object? obj) => Equals(obj as RBG_Result<T>);

  /// <summary>
  /// Serves as the default hash function.
  /// </summary>
  /// <returns>Hash code for object</returns>
  public override int GetHashCode() => (Message, Code).GetHashCode();
}
