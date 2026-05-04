using UnityEngine;

public class WeaponDoomModernSway : MonoBehaviour
{
[Header("Referência")]
[SerializeField] private Transform weaponTransform;

[Header("Bob ao andar")]
[SerializeField] private float bobSpeed = 8f;
[SerializeField] private float bobAmountX = 0.06f;
[SerializeField] private float bobAmountY = 0.04f;

[Header("Inclinação ao andar")]
[SerializeField] private float walkRotationAmountZ = 2.5f;

[Header("Sway do mouse")]
[SerializeField] private float mousePositionAmountX = 0.025f;
[SerializeField] private float mousePositionAmountY = 0.015f;
[SerializeField] private float mouseRotationAmountZ = 2.5f;

[Header("Limites do sway do mouse")]
[SerializeField] private float maxMouseOffsetX = 0.06f;
[SerializeField] private float maxMouseOffsetY = 0.04f;
[SerializeField] private float maxMouseRotationZ = 4f;

[Header("Suavização")]
[SerializeField] private float positionSmoothSpeed = 12f;
[SerializeField] private float rotationSmoothSpeed = 12f;
[SerializeField] private float mouseSwayReturnSpeed = 8f;

private Vector3 startLocalPosition;
private Quaternion startLocalRotation;

private float bobTimer;

private Vector2 mouseSwayOffset;
private float mouseSwayRotationZ;

private void Awake()
{
if (weaponTransform == null)
{
weaponTransform = transform;
}

startLocalPosition = weaponTransform.localPosition;
startLocalRotation = weaponTransform.localRotation;
}

private void LateUpdate()
{
ApplySway();
}

private void ApplySway()
{
float horizontal = Input.GetAxisRaw("Horizontal");
float vertical = Input.GetAxisRaw("Vertical");

float mouseX = Input.GetAxis("Mouse X");
float mouseY = Input.GetAxis("Mouse Y");

bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

Vector3 walkBobPosition = Vector3.zero;
float walkRotationZ = 0f;

if (isMoving)
{
bobTimer += Time.deltaTime * bobSpeed;

float bobX = Mathf.Sin(bobTimer) * bobAmountX;
float bobY = Mathf.Abs(Mathf.Cos(bobTimer)) * bobAmountY;

walkBobPosition = new Vector3(bobX, bobY, 0f);
walkRotationZ = -horizontal * walkRotationAmountZ;
}
else
{
bobTimer = 0f;
}

Vector2 targetMouseOffset = new Vector2(
-mouseX * mousePositionAmountX,
-mouseY * mousePositionAmountY
);

targetMouseOffset.x = Mathf.Clamp(targetMouseOffset.x, -maxMouseOffsetX, maxMouseOffsetX);
targetMouseOffset.y = Mathf.Clamp(targetMouseOffset.y, -maxMouseOffsetY, maxMouseOffsetY);

float targetMouseRotationZ = Mathf.Clamp(
-mouseX * mouseRotationAmountZ,
-maxMouseRotationZ,
maxMouseRotationZ
);

mouseSwayOffset = Vector2.Lerp(
mouseSwayOffset,
targetMouseOffset,
positionSmoothSpeed * Time.deltaTime
);

mouseSwayRotationZ = Mathf.Lerp(
mouseSwayRotationZ,
targetMouseRotationZ,
rotationSmoothSpeed * Time.deltaTime
);

if (Mathf.Abs(mouseX) < 0.01f && Mathf.Abs(mouseY) < 0.01f)
{
mouseSwayOffset = Vector2.Lerp(
mouseSwayOffset,
Vector2.zero,
mouseSwayReturnSpeed * Time.deltaTime
);

mouseSwayRotationZ = Mathf.Lerp(
mouseSwayRotationZ,
0f,
mouseSwayReturnSpeed * Time.deltaTime
);
}

Vector3 mousePosition = new Vector3(
mouseSwayOffset.x,
mouseSwayOffset.y,
0f
);

Vector3 targetPosition = startLocalPosition + walkBobPosition + mousePosition;

float finalRotationZ = walkRotationZ + mouseSwayRotationZ;

Quaternion targetRotation = startLocalRotation * Quaternion.Euler(
0f,
0f,
finalRotationZ
);

weaponTransform.localPosition = Vector3.Lerp(
weaponTransform.localPosition,
targetPosition,
positionSmoothSpeed * Time.deltaTime
);

weaponTransform.localRotation = Quaternion.Lerp(
weaponTransform.localRotation,
targetRotation,
rotationSmoothSpeed * Time.deltaTime
);
}
}