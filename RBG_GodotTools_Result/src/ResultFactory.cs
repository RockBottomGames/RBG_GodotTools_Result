namespace RBG_GodotTools_Result;

using System;

/// <summary>
/// RBG_Result (Immutable) class holds a message, an error code, and keeps track if it is an error,
/// and if it has been evaluated. Empty RBG_Result should be treated as success.
/// </summary>
public static class RBG_ResultFactory<T> where T : IEquatable<T> {
  /// <summary>
  /// Ensures produced Result Object is a success.
  /// </summary>
  /// <param name="value">The system corrected value, or null if it could not be corrected.</param>
  /// <param name="message">Message to describe the success.</param>
  public static RBG_Result<T> BuildSuccess(T? value = default, string message = "") => (
    new RBG_Result<T>(value, message, RBG_Result_Constants.SUCCESS_CODE)
  );

  /// <summary>
  /// Ensures produced Result Object is an error.
  /// </summary>
  /// <param name="value">The system corrected value, or null if it could not be corrected.</param>
  /// <param name="message">Message to describe the error.</param>
  /// <param name="code">
  /// Code to help identify specific errors. Default value and any codes below 1 are assigned to be 1 (GENERIC_DEVELOPER_ERROR)
  /// </param>
  public static RBG_Result<T> BuildError(
    T? value = default, string message = "",
    int code = RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE
  ) => (
    code < RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE
      ? new RBG_Result<T>(value, message, RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE)
      : new RBG_Result<T>(value, message, code)
  );
}
